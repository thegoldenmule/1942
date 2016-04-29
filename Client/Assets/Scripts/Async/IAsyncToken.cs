using System;
using System.Collections.Generic;

namespace Space
{
    /// <summary>
    /// Interface for asyncronous calls.
    /// 
    /// This is like a simplified promise.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncToken<T>
    {
        bool IsReady { get; }
        bool Success { get; }
        T Value { get; }
        Exception Exception { get; }

        /// <summary>
        /// Subscribed a callback for when the action is successful.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        IAsyncToken<T> OnSuccess(Action<T> callback);

        /// <summary>
        /// Subscribes a callback for when the action has failed.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        IAsyncToken<T> OnFailure(Action<Exception> callback);

        /// <summary>
        /// Subscribes a callback that is called regardless of success/fail.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        IAsyncToken<T> OnFinally(Action<IAsyncToken<T>> callback);

        /// <summary>
        /// Aborts all callbacks, none will be called.
        /// </summary>
        void Abort();

        /// <summary>
        /// Creates a token chained to this token.
        /// </summary>
        /// <returns></returns>
        IAsyncToken<T> Token();
    }

    public class AsyncToken<T> : IAsyncToken<T>
    {
        public bool IsReady { get; private set; }
        public bool Success { get; private set; }
        public T Value { get; private set; }
        public Exception Exception { get; private set; }

        private readonly List<Action<T>> _successActions = new List<Action<T>>();
        private readonly List<Action<Exception>> _failureActions = new List<Action<Exception>>();
        private readonly List<Action<IAsyncToken<T>>> _finallyActions = new List<Action<IAsyncToken<T>>>();

        private bool _isAborted;

        public AsyncToken()
        {
            
        }

        public AsyncToken(T value)
        {
            Succeed(value);
        }

        public AsyncToken(Exception exception)
        {
            Fail(exception);
        }

        public IAsyncToken<T> OnSuccess(Action<T> callback)
        {
            if (_isAborted)
            {
                return this;
            }

            if (IsReady)
            {
                if (Success)
                {
                    callback(Value);
                }
            }
            else
            {
                _successActions.Add(callback);
            }

            return this;
        }

        public IAsyncToken<T> OnFailure(Action<Exception> callback)
        {
            if (_isAborted)
            {
                return this;
            }

            if (IsReady)
            {
                if (!Success)
                {
                    callback(Exception);
                }
            }
            else
            {
                _failureActions.Add(callback);
            }

            return this;
        }

        public IAsyncToken<T> OnFinally(Action<IAsyncToken<T>> callback)
        {
            if (_isAborted)
            {
                return this;
            }

            if (IsReady)
            {
                callback(this);
            }
            else
            {
                _finallyActions.Add(callback);
            }

            return this;
        }

        public void Abort()
        {
            _isAborted = true;
        }

        public void Succeed(T value)
        {
            if (_isAborted)
            {
                return;
            }

            Value = value;
            IsReady = true;
            Success = true;

            for (int i = 0, len = _successActions.Count; i < len; i++)
            {
                _successActions[i].Invoke(value);
            }

            for (int i = 0, len = _finallyActions.Count; i < len; i++)
            {
                _finallyActions[i].Invoke(this);
            }
        }

        public void Fail(Exception exception)
        {
            if (_isAborted)
            {
                return;
            }

            Exception = exception;
            IsReady = true;
            Success = false;

            for (int i = 0, len = _failureActions.Count; i < len; i++)
            {
                _failureActions[i].Invoke(exception);
            }

            for (int i = 0, len = _finallyActions.Count; i < len; i++)
            {
                _finallyActions[i].Invoke(this);
            }
        }

        public IAsyncToken<T> Token()
        {
            var token = new AsyncToken<T>();

            OnSuccess(token.Succeed);
            OnFailure(token.Fail);

            return token;
        }
    }
}

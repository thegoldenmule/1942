namespace Space
{
    /// <summary>
    /// IStateMachine implementation.
    /// </summary>
    public class StateMachine : IStateMachine
    {
        /// <summary>
        /// The current state.
        /// </summary>
        private IState _state;
        
        /// <summary>
        /// Token for state exit.
        /// </summary>
        private IAsyncToken<IState> _exitStateToken;

        /// <summary>
        /// Gets/sets the current state.
        /// </summary>
        public IState State
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state == value)
                {
                    return;
                }

                if (null != _state)
                {
                    if (null != _exitStateToken)
                    {
                        _exitStateToken.Abort();
                    }

                    _exitStateToken = _state.Exit();
                    _exitStateToken
                        .OnSuccess(_ =>
                        {
                            _state = value;

                            if (null != _state)
                            {
                                _state.Enter();
                            }
                        })
                        .OnFinally(_ => _exitStateToken = null);
                }
                else
                {
                    _state = value;

                    if (null != _state)
                    {
                        _state.Enter();
                    }
                }
            }
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        /// <param name="dt"></param>
        public void DeltaUpdate(float dt)
        {
            if (null != _state)
            {
                _state.DeltaUpdate(dt);
            }
        }
    }
}
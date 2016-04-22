namespace Space
{
    public interface IState
    {
        void Enter();
        void DeltaUpdate(float dt);
        IAsyncToken<IState> Exit();
    }

    public interface IStateMachine
    {
        IState State { get; set; }
        void DeltaUpdate(float dt);
    }

    public class StateMachine : IStateMachine
    {
        private IState _state;
        
        private IAsyncToken<IState> _exitStateToken;

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

        public void DeltaUpdate(float dt)
        {
            if (null != _state)
            {
                _state.DeltaUpdate(dt);
            }
        }
    }
}
﻿namespace Space.Client
{
    public class InputController : InjectableMonoBehavior, IStateMachine
    {
        public CombatInputState Combat;

        private readonly StateMachine _fsm = new StateMachine();

        public IState State
        {
            get
            {
                return _fsm.State;
            }
            set
            {
                _fsm.State = value;
            }
        }

        public void DeltaUpdate(float dt)
        {
            _fsm.DeltaUpdate(dt);
        }
    }
}
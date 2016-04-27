namespace Space.Client
{
    /// <summary>
    /// Controls input.
    /// </summary>
    public class InputController : InjectableMonoBehavior, IStateMachine
    {
        /// <summary>
        /// Combat input state.
        /// </summary>
        public CombatInputState Combat;

        /// <summary>
        /// Backing fsm.
        /// </summary>
        private readonly StateMachine _fsm = new StateMachine();

        /// <summary>
        /// State to get/set.
        /// </summary>
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

        /// <summary>
        /// Called every frame.
        /// </summary>
        /// <param name="dt"></param>
        public void DeltaUpdate(float dt)
        {
            _fsm.DeltaUpdate(dt);
        }
    }
}
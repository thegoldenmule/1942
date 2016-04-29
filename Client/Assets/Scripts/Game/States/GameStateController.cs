namespace Space.Client
{
    /// <summary>
    /// Controls all game states.
    /// </summary>
    public class GameStateController : InjectableMonoBehavior, IStateMachine
    {
        /// <summary>
        /// Game states.
        /// </summary>
        public CombatState Combat;
        public EndGameState End;
        public GameOverState GameOver;
        public SplashState Splash;
        public HighScoresState HighScores;
        
        /// <summary>
        /// State machine.
        /// </summary>
        private readonly StateMachine _fsm = new StateMachine();

        /// <summary>
        /// Gets/sets the current state.
        /// </summary>
        public IState State
        {
            get { return _fsm.State; }
            set { _fsm.State = value; }
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
namespace Space.Client
{
    public class GameStateController : InjectableMonoBehavior, IStateMachine
    {
        public CombatState Combat;
        public EndGameState End;
        public SplashState Splash;
        
        private readonly StateMachine _fsm = new StateMachine();

        public IState State
        {
            get { return _fsm.State; }
            set { _fsm.State = value; }
        }

        public void DeltaUpdate(float dt)
        {
            _fsm.DeltaUpdate(dt);
        }
    }
}
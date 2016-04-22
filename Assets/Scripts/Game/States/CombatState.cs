using Ninject;

namespace Space.Client
{
    public class CombatState : GameState
    {
        [Inject]
        public GameStateController States { get; private set; }
        [Inject]
        public InputController Input { get; private set; }

        public GameEntity PlayerPrefab;

        private GameEntity _player;

        public override void Enter()
        {
            base.Enter();

            if (null == PlayerPrefab)
            {
                States.State = Failure;
                return;
            }

            // we don't need to pool as there is only 1 player
            _player = Instantiate(PlayerPrefab);

            Input.State = Input.Combat;
        }

        public override void DeltaUpdate(float dt)
        {
            base.DeltaUpdate(dt);

            Input.DeltaUpdate(dt);
        }

        public override IAsyncToken<IState> Exit()
        {
            return base.Exit();
        }
    }
}
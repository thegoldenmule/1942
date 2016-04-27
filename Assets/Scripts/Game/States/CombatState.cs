using Ninject;

namespace Space.Client
{
    public class CombatState : GameState
    {
        [Inject]
        public GameStateController States { get; private set; }
        [Inject]
        public InputController Input { get; private set; }
        [Inject]
        public ProjectileManager Projectiles { get; private set; }
        [Inject]
        public SpawnerManager Spawners { get; private set; }

        public override void Enter()
        {
            base.Enter();

            Input.State = Input.Combat;

            Spawners.Initialize();
        }

        public override void DeltaUpdate(float dt)
        {
            base.DeltaUpdate(dt);

            Input.DeltaUpdate(dt);
            Projectiles.DeltaUpdate(dt);
        }
    }
}
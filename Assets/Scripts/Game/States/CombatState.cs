using Ninject;

namespace Space.Client
{
    /// <summary>
    /// Main combat state.
    /// </summary>
    public class CombatState : GameState
    {
        /// <summary>
        /// Dependencies.
        /// </summary>
        [Inject]
        public GameStateController States { get; private set; }
        [Inject]
        public InputController Input { get; private set; }
        [Inject]
        public ProjectileManager Projectiles { get; private set; }
        [Inject]
        public SpawnerManager Spawners { get; private set; }

        /// <summary>
        /// Called when state is exited.
        /// </summary>
        public override void Enter()
        {
            base.Enter();

            Input.State = Input.Combat;

            Spawners.Initialize();
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        /// <param name="dt"></param>
        public override void DeltaUpdate(float dt)
        {
            base.DeltaUpdate(dt);

            Input.DeltaUpdate(dt);
            Projectiles.DeltaUpdate(dt);
        }
    }
}
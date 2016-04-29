using System;
using System.Linq;
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
        [Inject]
        public EntityManager Entities { get; private set; }
        [Inject]
        public UIController UI { get; private set; }

        /// <summary>
        /// The score of the game.
        /// </summary>
        private int _score = 0;

        /// <summary>
        /// Called when state is exited.
        /// </summary>
        public override void Enter()
        {
            base.Enter();

            Input.State = Input.Combat;

            Spawners.Initialize();

            _score = 0;

            Entities.OnAdded += Entities_OnAdded;
            Entities.OnRemoved += Entities_OnRemoved;
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

        /// <summary>
        /// Called when state is exited.
        /// </summary>
        /// <returns></returns>
        public override IAsyncToken<IState> Exit()
        {
            Entities.OnAdded -= Entities_OnAdded;
            Entities.OnRemoved -= Entities_OnRemoved;

            var entities = Entities.Entities.ToArray();
            foreach (var entity in entities)
            {
                entity.Uninitialize();
            }

            var projectiles = Projectiles.All.ToArray();
            foreach (var projectile in projectiles)
            {
                projectile.Uninitialize();
            }

            return base.Exit();
        }

        /// <summary>
        /// Called when an entity has been removed.
        /// </summary>
        /// <param name="gameEntity"></param>
        private void Entities_OnRemoved(GameEntity gameEntity)
        {
            gameEntity.OnDeath -= EnemyEntity_OnDeath;
        }

        /// <summary>
        /// Called when an entity has been added.
        /// </summary>
        /// <param name="gameEntity"></param>
        private void Entities_OnAdded(GameEntity gameEntity)
        {
            if (gameEntity == Entities.Player)
            {
                gameEntity.OnDeath += Player_OnDeath;
            }
            else
            {
                gameEntity.OnDeath += EnemyEntity_OnDeath;
            }
        }

        /// <summary>
        /// Called when player dies.
        /// </summary>
        /// <param name="gameEntity"></param>
        private void Player_OnDeath(GameEntity gameEntity)
        {
            States.State = States.GameOver;
        }

        /// <summary>
        /// Called when an entity dies.
        /// </summary>
        /// <param name="gameEntity"></param>
        private void EnemyEntity_OnDeath(GameEntity gameEntity)
        {
            _score += gameEntity.Definition.Score;

            if (null != UI.ScoreText)
            {
                UI.ScoreText.text = _score.ToString();
            }
        }
    }
}
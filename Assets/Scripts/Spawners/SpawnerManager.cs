using System.Collections.Generic;
using Ninject;

namespace Space.Client
{
    /// <summary>
    /// Manages spawners.
    /// </summary>
    public class SpawnerManager : InjectableMonoBehavior
    {
        /// <summary>
        /// Dependencies.
        /// </summary>
        [Inject]
        public GameStateController States { get; private set; }

        /// <summary>
        /// Waves.
        /// </summary>
        public SpawnerGroup[] Waves;

        /// <summary>
        /// List of entities we're watching.
        /// </summary>
        private readonly List<GameEntity> _watched = new List<GameEntity>();

        /// <summary>
        /// Index to wave we spawn.
        /// </summary>
        private int _index = 0;

        /// <summary>
        /// True iff initialized.
        /// </summary>
        private bool _started;

        /// <summary>
        /// Initializes the spawners.
        /// </summary>
        public void Initialize()
        {
            _started = true;
            _index = 0;
        }

        /// <summary>
        /// Uninitializes the spawners.
        /// </summary>
        public void Uninitialize()
        {
            _started = false;
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        private void Update()
        {
            if (!_started)
            {
                return;
            }

            if (0 == _watched.Count)
            {
                if (Waves.Length > _index)
                {
                    var wave = Waves[_index++];
                    var entities = wave.Spawn();
                    foreach (var entity in entities)
                    {
                        entity.OnDeath += Entity_OnDeath;
                    }

                    _watched.AddRange(entities);
                }
                else
                {
                    States.State = States.End;
                }
            }
        }

        /// <summary>
        /// Called when an entity dies.
        /// </summary>
        /// <param name="entity"></param>
        private void Entity_OnDeath(GameEntity entity)
        {
            _watched.Remove(entity);

            entity.OnDeath -= Entity_OnDeath;
        }
    }
}
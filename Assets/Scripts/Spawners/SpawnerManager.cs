using System.Collections.Generic;
using System.Diagnostics;
using Ninject;

namespace Space.Client
{
    public class SpawnerManager : InjectableMonoBehavior
    {
        [Inject]
        public GameStateController States { get; private set; }

        public SpawnerGroup[] Waves;

        private readonly List<GameEntity> _watched = new List<GameEntity>();
        private int _index = 0;
        private bool _started;

        public void Initialize()
        {
            _started = true;
        }

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

        private void Entity_OnDeath(GameEntity entity)
        {
            _watched.Remove(entity);

            entity.OnDeath -= Entity_OnDeath;
        }
    }
}
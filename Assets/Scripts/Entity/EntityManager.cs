using System.Collections.Generic;

namespace Space.Client
{
    public class EntityManager
    {
        private readonly List<GameEntity> _entities = new List<GameEntity>();
        private readonly List<GameEntity> _enemies = new List<GameEntity>();

        public GameEntity Player { get; private set; }

        public IList<GameEntity> Entities
        {
            get
            {
                return _entities;
            }
        }

        public IList<GameEntity> Enemies
        {
            get
            {
                return _enemies;
            }
        }

        public void Add(GameEntity entity)
        {
            _entities.Add(entity);

            if (entity.tag == Tags.Player)
            {
                Player = entity;
            }
            else
            {
                _enemies.Add(entity);
            }
        }

        public void Remove(GameEntity entity)
        {
            _entities.Remove(entity);

            if (entity.tag == Tags.Player)
            {
                Player = null;
            }
            else
            {
                _enemies.Remove(entity);
            }
        }
    }
}

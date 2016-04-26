using System.Collections.Generic;
using UnityEngine;

namespace Space.Client
{
    public class EntityManager
    {
        private readonly List<GameEntity> _entities = new List<GameEntity>();
        private readonly List<GameEntity> _enemies = new List<GameEntity>();

        public PlayerGameEntity Player { get; private set; }

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
                var player = entity as PlayerGameEntity;
                if (null != player)
                {
                    Player = player;
                }
                else
                {
                    Debug.LogWarning(string.Format("Non-PlayerGameEntity tagged as Player : {0}.", entity.name));
                }
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

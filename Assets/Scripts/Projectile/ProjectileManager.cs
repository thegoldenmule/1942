using System.Collections.Generic;
using UnityEngine;

namespace Space.Client
{
    public class ProjectileManager
    {
        private readonly List<Projectile> _projectiles = new List<Projectile>();
        private readonly PoolManager _pools;

        public ProjectileManager(PoolManager pools)
        {
            _pools = pools;
        }

        public void Fire(
            GameEntity source,
            WeaponDefinition weapon,
            Vector3 start,
            Vector3 direction)
        {
            if (null == weapon.Prefab)
            {
                return;
            }

            var instance = _pools.Get<Projectile>(weapon.Prefab.gameObject);
            instance.Initialize(source, weapon, start, direction);

            _projectiles.Add(instance);
        }

        public void DeltaUpdate(float dt)
        {
            for (var i = 0; i < _projectiles.Count;)
            {
                var projectile = _projectiles[i];
                if (!projectile.DeltaUpdate(dt))
                {
                    _pools.Put(projectile.gameObject);

                    _projectiles.RemoveAt(i);
                }
                else
                {
                    // check if out of bounds

                    i++;
                }
            }
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// Manages projectiles.
    /// </summary>
    public class ProjectileManager
    {
        /// <summary>
        /// List of projectiles.
        /// </summary>
        private readonly List<Projectile> _projectiles = new List<Projectile>();

        /// <summary>
        /// Pools.
        /// </summary>
        private readonly PoolManager _pools;

        /// <summary>
        /// Retrieves all projectiles.
        /// </summary>
        public List<Projectile> All
        {
            get
            {
                return _projectiles;
            }
        } 

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pools"></param>
        public ProjectileManager(PoolManager pools)
        {
            _pools = pools;
        }

        /// <summary>
        /// Called to fire a projectile.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="weapon"></param>
        /// <param name="start"></param>
        /// <param name="direction"></param>
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

        /// <summary>
        /// Called every frame.
        /// </summary>
        /// <param name="dt"></param>
        public void DeltaUpdate(float dt)
        {
            for (var i = 0; i < _projectiles.Count;)
            {
                var projectile = _projectiles[i];
                if (!projectile.DeltaUpdate(dt))
                {
                    projectile.Uninitialize();

                    _projectiles.RemoveAt(i);
                }
                else
                {
                    // TODO: check if out of bounds

                    i++;
                }
            }
        }
    }
}
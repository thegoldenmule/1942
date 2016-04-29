using System.Collections.Generic;
using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// A collection of spawners.
    /// </summary>
    public class SpawnerGroup : MonoBehaviour
    {
        /// <summary>
        /// Spawners to aggregate.
        /// </summary>
        public Spawner[] Spawners;

        /// <summary>
        /// Called to spawn entities.
        /// </summary>
        /// <returns></returns>
        public GameEntity[] Spawn()
        {
            var entities = new List<GameEntity>();

            foreach (var spawner in Spawners)
            {
                entities.AddRange(spawner.Spawn());
            }

            return entities.ToArray();
        }
    }
}
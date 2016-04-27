using System.Collections.Generic;
using UnityEngine;

namespace Space.Client
{
    public class SpawnerGroup : MonoBehaviour
    {
        public Spawner[] Spawners;

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
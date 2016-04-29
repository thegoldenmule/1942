using Ninject;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Space.Client
{
    /// <summary>
    /// Spawns an entity.
    /// </summary>
    public class Spawner : InjectableMonoBehavior
    {
        /// <summary>
        /// Dependencies.
        /// </summary>
        [Inject]
        public EntityFactory Entities { get; private set; }

        /// <summary>
        /// The entity to spawn.
        /// </summary>
        public EntityDefinition Entity;

        /// <summary>
        /// Position variance.
        /// </summary>
        public Rect Variance = new Rect(0, 0, 0, 0);

        /// <summary>
        /// Spawns game entities.
        /// </summary>
        /// <returns></returns>
        public virtual GameEntity[] Spawn()
        {
            GameEntity instance = null;

            if (null != Entity)
            {
                var position = transform.position;
                var spawnPosition = new Vector3(
                    position.x + Random.Range(Variance.xMin, Variance.xMax),
                    position.y,
                    position.z + Random.Range(Variance.yMin, Variance.yMax));

                instance = Entities.Entity(Entity);
                instance.transform.position = instance.transform.position = spawnPosition;
                instance.transform.rotation = transform.rotation;
            }

            return new []
            {
                instance
            };
        }

        /// <summary>
        /// Draws gizmos.
        /// </summary>
        private void OnDrawGizmos()
        {
            var position = transform.position;

            Gizmos.color = Color.red;

            Gizmos.DrawWireCube(position, Vector3.one);

            Gizmos.color = Color.yellow;

            Gizmos.DrawLine(
                position + new Vector3(Variance.xMin, 0, Variance.yMin),
                position + new Vector3(Variance.xMax, 0, Variance.yMin));

            Gizmos.DrawLine(
                position + new Vector3(Variance.xMax, 0, Variance.yMin),
                position + new Vector3(Variance.xMax, 0, Variance.yMax));

            Gizmos.DrawLine(
                position + new Vector3(Variance.xMax, 0, Variance.yMax),
                position + new Vector3(Variance.xMin, 0, Variance.yMax));

            Gizmos.DrawLine(
                position + new Vector3(Variance.xMin, 0, Variance.yMax),
                position + new Vector3(Variance.xMin, 0, Variance.yMin));
        }
    }
}
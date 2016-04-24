using System.Collections;
using Ninject;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Space.Client
{
    public class Spawner : InjectableMonoBehavior
    {
        [Inject]
        public PoolManager Pools { get; private set; }

        public GameEntity EntityPrefab;

        public Rect Variance = new Rect(0, 0, 0, 0);

        public bool SpawnOnStart = false;
        public float DelaySeconds;
        public bool DisableOnSpawn = true;

        public void Spawn()
        {
            if (Mathf.Approximately(DelaySeconds, 0f))
            {
                SpawnInternal();

                return;
            }

            StartCoroutine(WaitForSpawn());
        }

        private void Start()
        {
            if (SpawnOnStart)
            {
                Spawn();
            }
        }

        protected virtual void SpawnInternal()
        {
            var position = transform.position;
            var spawnPosition = new Vector3(
                position.x + Random.Range(Variance.xMin, Variance.xMax),
                position.y,
                position.z + Random.Range(Variance.yMin, Variance.yMax));

            var instance = Pools.Get<GameEntity>(EntityPrefab.gameObject);
            instance.transform.position = instance.Model.Position = spawnPosition;

            if (DisableOnSpawn)
            {
                enabled = false;
            }
        }

        private IEnumerator WaitForSpawn()
        {
            yield return new WaitForSeconds(DelaySeconds);

            SpawnInternal();
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

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
using System.Collections.Generic;
using UnityEngine;

namespace Space.Client
{
    public class PoolManager : MonoBehaviour
    {
        private readonly Dictionary<int, ObjectPool<GameObject>> _pools = new Dictionary<int, ObjectPool<GameObject>>();
        private readonly Dictionary<GameObject, int> _poolIds = new Dictionary<GameObject, int>(); 
        private Transform _inactive;
        private Transform _active;

        public T Get<T>(GameObject prefab) where T : class
        {
            var id = prefab.GetInstanceID();

            ObjectPool<GameObject> pool;
            if (!_pools.TryGetValue(id, out pool))
            {
                // Default to lazily create pool. In a production game, I would
                // also add PoolConfigs that could specify the number to
                // preallocate and grow by statically.
                pool = _pools[id] = new ObjectPool<GameObject>(() =>
                {
                    var poolInstance = Instantiate(prefab);
                    poolInstance.transform.parent = _inactive;

                    return poolInstance;
                }, 4, 4);
            }

            var instance = pool.Get();
            instance.transform.parent = _active;

            _poolIds[instance] = id;

            if (typeof (T) == typeof (GameObject))
            {
                return instance as T;
            }

            return instance.GetComponentInChildren<T>();
        }

        public bool Put(GameObject gameObject)
        {
            int id;
            if (!_poolIds.TryGetValue(gameObject, out id))
            {
                return false;
            }

            gameObject.transform.parent = _inactive;

            _poolIds.Remove(gameObject);
            _pools[id].Put(gameObject);

            return true;
        }

        private void Awake()
        {
            _inactive = new GameObject("Inactive").transform;
            _inactive.parent = transform;
            _inactive.gameObject.SetActive(false);

            _active = new GameObject("Active").transform;
            _active.parent = transform;
        }
    }
}
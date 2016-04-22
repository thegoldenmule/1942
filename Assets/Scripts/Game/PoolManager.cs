using System.Collections.Generic;
using UnityEngine;

namespace Space.Client
{
    public class PoolManager : InjectableMonoBehavior
    {
        private readonly Dictionary<GameObject, ObjectPool<GameObject>> _pools = new Dictionary<GameObject, ObjectPool<GameObject>>();
        private Transform _inactive;
        private Transform _active;

        public T Get<T>(GameObject prefab) where T : class
        {
            ObjectPool<GameObject> pool;
            if (!_pools.TryGetValue(prefab, out pool))
            {
                // Default to lazily create pool. In a production game, I would
                // also add PoolConfigs that could specify the number to
                // preallocate and grow by statically.
                pool = _pools[prefab] = new ObjectPool<GameObject>(() =>
                {
                    var poolInstance = Instantiate(prefab);
                    poolInstance.transform.parent = _inactive;

                    return poolInstance;
                }, 4, 4);
            }

            var instance = pool.Get();
            instance.transform.parent = _active;

            if (typeof (T) == typeof (GameObject))
            {
                return instance as T;
            }

            return instance.GetComponentInChildren<T>();
        }

        private void Awake()
        {
            _inactive = new GameObject("Inactive").transform;
            _inactive.parent = transform;
            _inactive.gameObject.SetActive(false);

            _inactive = new GameObject("Active").transform;
            _inactive.parent = transform;
        }
    }
}
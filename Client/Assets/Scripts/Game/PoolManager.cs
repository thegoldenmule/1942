using System.Collections.Generic;
using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// Manages pools.
    /// </summary>
    public class PoolManager : MonoBehaviour
    {
        /// <summary>
        /// Pool per game object id.
        /// </summary>
        private readonly Dictionary<int, ObjectPool<GameObject>> _pools = new Dictionary<int, ObjectPool<GameObject>>();

        /// <summary>
        /// Pool id per instance.
        /// </summary>
        private readonly Dictionary<GameObject, int> _poolIds = new Dictionary<GameObject, int>(); 

        /// <summary>
        /// Transforms for active/inactive.
        /// </summary>
        private Transform _inactive;
        private Transform _active;

        /// <summary>
        /// Retrieves a pooled T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefab"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Puts a gameObject back in the pool.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Called ASAP.
        /// </summary>
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
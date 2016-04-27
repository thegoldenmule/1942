using System;
using System.Collections.Generic;

namespace Space.Client
{
    /// <summary>
    /// Very basic pool.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T>
    {
        private readonly HashSet<T> _usedInstances = new HashSet<T>();
        private readonly List<T> _availableInstances = new List<T>();

        private readonly Func<T> _factory;
        private readonly int _numToGrow;

        public ObjectPool(
            Func<T> factory,
            int numToAllocate,
            int numToGrow)
        {
            _factory = factory;
            _numToGrow = numToGrow;

            Allocate(numToAllocate);
        }

        public T Get()
        {
            var len = _availableInstances.Count;
            if (0 == len)
            {
                if (0 == _numToGrow)
                {
                    return default(T);
                }

                Allocate(_numToGrow);
            }

            if (0 == _availableInstances.Count)
            {
                return default(T);
            }

            var instance = _availableInstances[0];
            _availableInstances.RemoveAt(0);
            _usedInstances.Add(instance);

            return instance;
        }

        public void Put(T instance)
        {
            if (!_usedInstances.Remove(instance))
            {
                // this wasn't part of the pool
                return;
            }

            _availableInstances.Add(instance);
        }

        private void Allocate(int num)
        {
            while (num-- > 0)
            {
                _availableInstances.Add(_factory());
            }
        }
    }
}
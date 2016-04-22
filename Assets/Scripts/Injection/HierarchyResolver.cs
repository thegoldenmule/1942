using Ninject.Activation;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Space.Client
{
    /// <summary>
    /// Resolves implementations from the Unity project hierarchy.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HierarchyResolver<T> : Provider<T> where T : Object
    {
        /// <summary>
        /// The tag at which to begin the search.
        /// </summary>
        private readonly string _tag;

        /// <summary>
        /// A tag at which to start the recursive search.
        /// </summary>
        /// <param name="tag"></param>
        public HierarchyResolver(string tag)
        {
            _tag = tag;
        }

        /// <summary>
        /// We have to use ninjects projected name
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public T CreateInstanceExternal(IContext context)
        {
            return CreateInstance(context);
        }

        /// <summary>
        /// Provider implementation.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override T CreateInstance(IContext context)
        {
            var taggedObject = GameObject.FindGameObjectWithTag(_tag);
            if (null != taggedObject)
            {
                if (typeof(Component).IsAssignableFrom(typeof(T)))
                {
                    return taggedObject.GetComponentInChildren<T>();
                }

                if (typeof(GameObject) == typeof(T))
                {
                    return taggedObject as T;
                }
            }

            return null;
        }
    }
}
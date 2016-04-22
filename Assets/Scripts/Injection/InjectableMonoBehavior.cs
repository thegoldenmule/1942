using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// Base class for monobehaviours that need injection.
    /// </summary>
    public class InjectableMonoBehavior : MonoBehaviour
    {
        /// <summary>
        /// Called as part of monobehaviour lifecycle.
        /// </summary>
        private void Awake()
        {
            Debug.Log("Inject " + GetType().Name);
            Director.Inject(this);
        }
    }
}
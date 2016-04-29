using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// Bootstraps the Director, which separates if from Unity.
    /// </summary>
    public class Bootstrap : MonoBehaviour
    {
        /// <summary>
        /// Director instance.
        /// </summary>
        private Director _director;

        /// <summary>
        /// Called as initializer.
        /// </summary>
        private void Awake()
        {
            _director = new Director();
        }

        /// <summary>
        /// After all MonoBehaviours have been given a change to awake, we can
        /// start the director.
        /// </summary>
        private void Start()
        {
            _director.Start();
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        private void Update()
        {
            _director.Update(Time.deltaTime);
        }

        /// <summary>
        /// Called after Update every frame.
        /// </summary>
        private void LateUpdate()
        {
            _director.LateUpdate();
        }

        /// <summary>
        /// Called when we quit the application.
        /// </summary>
        private void OnApplicationQuit()
        {
            _director.OnApplicationQuit();
        }
    }
}
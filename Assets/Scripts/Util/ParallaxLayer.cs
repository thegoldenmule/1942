using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// A moving parallax layer.
    /// </summary>
    public class ParallaxLayer : MonoBehaviour
    {
        /// <summary>
        /// Uniform pointer.
        /// </summary>
        private int _uvScroll;

        /// <summary>
        /// Material we scroll.
        /// </summary>
        private Material _material;

        /// <summary>
        /// Elapsed time.
        /// </summary>
        private float _elapsed;

        /// <summary>
        /// The multiplier for this parallax layer.
        /// </summary>
        public float ScrollPercentage;

        /// <summary>
        /// Called as initializer.
        /// </summary>
        private void Awake()
        {
            _uvScroll = Shader.PropertyToID("_uvScroll");
            _material = GetComponent<Renderer>().material;
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        private void Update()
        {
            _elapsed += Time.deltaTime;
            _material.SetFloat(_uvScroll, ScrollPercentage * _elapsed);
        }
    }
}
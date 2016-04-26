using UnityEngine;

namespace Space.Client
{
    public class ParallaxLayer : MonoBehaviour
    {
        private int _uvScroll;
        private Material _material;
        private float _elapsed;

        public float ScrollPercentage;

        private void Awake()
        {
            _uvScroll = Shader.PropertyToID("_uvScroll");
            _material = GetComponent<Renderer>().material;
        }

        private void Update()
        {
            _elapsed += Time.deltaTime;
            _material.SetFloat(_uvScroll, ScrollPercentage * _elapsed);
        }
    }
}
using UnityEngine;

namespace Space.Client
{
    public class ParallaxScroller : MonoBehaviour
    {
        public ParallaxLayer[] Layers;

        private void Update()
        {
            var dt = Time.deltaTime;
        }
    }
}
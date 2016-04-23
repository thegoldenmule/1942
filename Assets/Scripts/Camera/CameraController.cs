using Ninject;
using UnityEngine;

namespace Space.Client
{
    public class CameraController : InjectableMonoBehavior
    {
        [Inject]
        public Camera MainCamera { get; private set; }

        private void OnDrawGizmos()
        {
            var sceneCamera = MainCamera ?? Camera.main;
            if (null == sceneCamera)
            {
                return;
            }

            var width = Screen.width;
            var height = Screen.height;

            var topLeft = GroundPlaneIntersection(sceneCamera, new Vector2(0, 0));
            var topRight = GroundPlaneIntersection(sceneCamera, new Vector2(width, 0));
            var bottomRight = GroundPlaneIntersection(sceneCamera, new Vector2(width, height));
            var bottomLeft = GroundPlaneIntersection(sceneCamera, new Vector2(0, height));

            Gizmos.DrawLine(topLeft, topRight);
            Gizmos.DrawLine(topRight, bottomRight);
            Gizmos.DrawLine(bottomRight, bottomLeft);
            Gizmos.DrawLine(bottomLeft, topLeft);
        }

        private static Vector3 GroundPlaneIntersection(Camera camera, Vector2 screenPosition)
        {
            var ray = camera.ScreenPointToRay(screenPosition);

            var t = -ray.origin.y / ray.direction.y;
            return ray.origin + t * ray.direction;
        }
    }
}
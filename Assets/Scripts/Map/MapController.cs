using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// Controls the map.
    /// </summary>
    public class MapController : InjectableMonoBehavior
    {
        /// <summary>
        /// Visible bounds of the map.
        /// </summary>
        public Bounds Bounds;

        /// <summary>
        /// Draws gizmos for the map.
        /// </summary>
        private void OnDrawGizmos()
        {
            var min = Bounds.min;
            var max = Bounds.max;

            // bottom
            Gizmos.DrawLine(
                min,
                new Vector3(max.x, min.y, min.z));
            Gizmos.DrawLine(
                new Vector3(max.x, min.y, min.z),
                new Vector3(max.x, min.y, max.z));
            Gizmos.DrawLine(
                new Vector3(max.x, min.y, max.z),
                new Vector3(min.x, min.y, max.z));
            Gizmos.DrawLine(
                new Vector3(min.x, min.y, max.z),
                min);

            // top
            Gizmos.DrawLine(
                new Vector3(min.x, max.y, min.z),
                new Vector3(max.x, max.y, min.z));
            Gizmos.DrawLine(
                new Vector3(max.x, max.y, min.z),
                new Vector3(max.x, max.y, max.z));
            Gizmos.DrawLine(
                new Vector3(max.x, max.y, max.z),
                new Vector3(min.x, max.y, max.z));
            Gizmos.DrawLine(
                new Vector3(min.x, max.y, max.z),
                new Vector3(min.x, max.y, min.z));

            // sides
            Gizmos.DrawLine(
                min,
                new Vector3(min.x, max.y, min.z));
            Gizmos.DrawLine(
                new Vector3(max.x, min.y, min.z),
                new Vector3(max.x, max.y, min.z));
            Gizmos.DrawLine(
                new Vector3(max.x, min.y, max.z),
                new Vector3(max.x, max.y, max.z));
            Gizmos.DrawLine(
                new Vector3(min.x, min.y, max.z),
                new Vector3(min.x, max.y, max.z));
        }
    }
}
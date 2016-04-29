using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// Utility functions for drawing gizmos.
    /// </summary>
    public static class GizmosUtil
    {
        /// <summary>
        /// Draws bounds.
        /// </summary>
        /// <param name="bounds"></param>
        public static void DrawBounds(Bounds bounds)
        {
            var min = bounds.min;
            var max = bounds.max;

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
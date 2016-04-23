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
        public Bounds PlayerBounds;

        /// <summary>
        /// Draws gizmos for the map.
        /// </summary>
        private void OnDrawGizmos()
        {
            GizmosUtil.DrawBounds(PlayerBounds);
        }
    }
}
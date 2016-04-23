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
        /// Visible bounds of map.
        /// </summary>
        public Bounds MapBounds;

        /// <summary>
        /// Draws gizmos for the map.
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            GizmosUtil.DrawBounds(PlayerBounds);
            Gizmos.color = Color.white;
            GizmosUtil.DrawBounds(MapBounds);
        }
    }
}
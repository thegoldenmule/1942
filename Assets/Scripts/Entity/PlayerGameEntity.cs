using UnityEngine;

namespace Space.Client
{
    public class PlayerGameEntity : GameEntity
    {
        public Bounds Bounds = new Bounds(Vector3.zero, Vector3.zero);

        public float SpringStiffness = 100;
        public float Damping = 10;

        protected override void Update()
        {
            var position = _transform.position;
            if (!Bounds.Contains(position))
            {
                var closest = Bounds.ClosestPoint(position);
                var delta = position - closest;

                // add spring force (Hooke's law + some velocity based damping)
                Model.Forces += -SpringStiffness * delta - Damping * Model.Velocity;
            }

            base.Update();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            GizmosUtil.DrawBounds(Bounds);
        }
    }
}
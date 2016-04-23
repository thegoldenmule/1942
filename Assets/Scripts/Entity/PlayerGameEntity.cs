using Ninject;

namespace Space.Client
{
    public class PlayerGameEntity : GameEntity
    {
        [Inject]
        public MapController Map { get; private set; }

        public float SpringStiffness = 1000;
        public float Damping = 10;

        protected override void Update()
        {
            var position = _transform.position;
            var bounds = Map.PlayerBounds;
            if (!bounds.Contains(position))
            {
                var closest = bounds.ClosestPoint(position);
                var delta = position - closest;

                // add spring force (Hooke's law + some velocity based damping)
                Model.Forces += -SpringStiffness * delta - Damping * Model.Velocity;
            }

            base.Update();
        }
    }
}
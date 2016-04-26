using Ninject;
using UnityEngine;

namespace Space.Client
{
    public class PlayerGameEntity : GameEntity
    {
        [Inject]
        public MapController Map { get; private set; }

        public PhysicsController Physics = new PhysicsController();

        public float SpringStiffness = 1000;
        public float Damping = 10;

        public override void Initialize(EntityDefinition definition)
        {
            base.Initialize(definition);

            if (null != Physics)
            {
                Physics.Initialize(this);
            }
        }

        protected override void Update()
        {
            base.Update();

            UpdateModel();
        }

        private void LateUpdate()
        {
            _transform.position = Physics.Position;
            _transform.localRotation = Physics.Rotation;
            _transform.localScale = Physics.Scale;
        }

        private void UpdateModel()
        {
            var position = _transform.position;
            var bounds = Map.PlayerBounds;
            if (!bounds.Contains(position))
            {
                var closest = bounds.ClosestPoint(position);
                var delta = position - closest;

                // add spring force (Hooke's law + some velocity based damping)
                Physics.Forces += -SpringStiffness * delta - Damping * Physics.Velocity;
            }

            var dt = Time.deltaTime;
            var iterations = Mathf.Max(1, Definition.Physics.Iterations);
            var step = dt / iterations;
            while (iterations-- > 0)
            {
                Physics.Step(step);
            }
        }
    }
}
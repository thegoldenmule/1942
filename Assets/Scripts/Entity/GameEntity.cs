using Ninject;
using UnityEngine;

namespace Space.Client
{
    public class GameEntity : InjectableMonoBehavior
    {
        [Inject]
        public EntityManager Entities { get; private set; }

        public EntityDefinition Definition { get; private set; }

        public PhysicsController Model;
        public StatController Stats;
        public AIController Agent;
        
        protected Transform _transform;

        public void Initialize(EntityDefinition definition)
        {
            Definition = definition;

            if (null != Agent)
            {
                Agent.Initialize(this);
            }

            if (null != Model)
            {
                Model.Initialize(this);
            }

            if (null != Stats)
            {
                Stats.Initialize(this);
            }
        }

        protected override void Awake()
        {
            base.Awake();

            _transform = transform;
        }

        private void OnEnable()
        {
            Entities.Add(this);
        }

        private void OnDisable()
        {
            Entities.Remove(this);
        }

        protected virtual void Update()
        {
            var dt = Time.deltaTime;
            var iterations = Mathf.Max(1, Definition.Physics.Iterations);
            var step = dt/iterations;
            while (iterations-- > 0)
            {
                Model.Step(step);
            }

            _transform.position = Model.Position;
            _transform.localRotation = Model.Rotation;
            _transform.localScale = Model.Scale;
        }
    }
}
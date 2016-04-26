using Ninject;
using UnityEngine;

namespace Space.Client
{
    public class GameEntity : InjectableMonoBehavior
    {
        [Inject]
        public EntityManager Entities { get; private set; }

        public EntityDefinition Definition { get; private set; }

        public StatController Stats;
        public AIController Agent;
        public MovementController Movement;
        
        protected Transform _transform;

        public virtual void Initialize(EntityDefinition definition)
        {
            Definition = definition;

            if (null != Agent)
            {
                Agent.Initialize(this);
            }

            if (null != Stats)
            {
                Stats.Initialize(this);
            }

            if (null != Movement)
            {
                Movement.Initialize(this);
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

            Stats.DeltaUpdate(dt);
            Agent.DeltaUpdate(dt);
        }
    }
}
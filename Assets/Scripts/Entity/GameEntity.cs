using Ninject;
using UnityEngine;

namespace Space.Client
{
    public class GameEntity : InjectableMonoBehavior
    {
        [Inject]
        public EntityManager Entities { get; private set; }
        [Inject]
        public PoolManager Pools { get; private set; }

        public EntityDefinition Definition { get; private set; }

        public StatController Stats;
        public AIController Agent;
        public WeaponController Weapons;
        
        protected Transform _transform;
        
        public virtual void Initialize(EntityDefinition definition)
        {
            Definition = definition;

            if (null != Stats)
            {
                Stats.Initialize(this);
            }

            if (null != Agent)
            {
                Agent.Initialize(this);
            }

            if (null != Weapons)
            {
                Weapons.Initialize(this);
            }

            Stats.Stat(StatType.Health).OnUpdated += Stat_OnHealthUpdated;
        }

        protected override void Awake()
        {
            base.Awake();

            _transform = transform;
        }

        protected virtual void OnEnable()
        {
            Entities.Add(this);
        }

        protected virtual void OnDisable()
        {
            Entities.Remove(this);
        }

        protected virtual void Update()
        {
            var dt = Time.deltaTime;

            Stats.DeltaUpdate(dt);
            Agent.DeltaUpdate(dt);
        }

        protected virtual void Die()
        {
            Pools.Put(gameObject);
        }

        private void Stat_OnHealthUpdated(Stat stat, float oldValue, float newValue)
        {
            if (newValue <= 0f)
            {
                Die();
            }
        }

        private void OnDrawGizmos()
        {
            if (null == Definition)
            {
                return;
            }

            Gizmos.color = Color.green;
            GizmosUtil.DrawBounds(new Bounds(
                transform.position + Definition.Bounds.center,
                Definition.Bounds.size));
        }
    }
}
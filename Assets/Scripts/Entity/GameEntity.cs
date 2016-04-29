using System;
using Ninject;
using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// Base class for all entities in the game.
    /// </summary>
    public class GameEntity : InjectableMonoBehavior
    {
        /// <summary>
        /// Dependencies.
        /// </summary>
        [Inject]
        public EntityManager Entities { get; private set; }
        [Inject]
        public PoolManager Pools { get; private set; }

        /// <summary>
        /// Definition of the entity.
        /// </summary>
        public EntityDefinition Definition { get; private set; }

        /// <summary>
        /// Subsystems.
        /// </summary>
        public StatController Stats;
        public AIController Agent;
        public WeaponController Weapons;

        /// <summary>
        /// Called when entity dies.
        /// </summary>
        public event Action<GameEntity> OnDeath; 
        
        /// <summary>
        /// Cached transform.
        /// </summary>
        protected Transform _transform;
        
        /// <summary>
        /// Preps the entity for play.
        /// </summary>
        /// <param name="definition"></param>
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

            if (null != Stats)
            {
                Stats.Stat(StatType.Health).OnUpdated += Stat_OnHealthUpdated;
            }
        }

        /// <summary>
        /// Called to unitialize the entity.
        /// </summary>
        public virtual void Uninitialize()
        {
            if (null != Stats)
            {
                Stats.Uninitialize();
            }

            Pools.Put(gameObject);
        }

        /// <summary>
        /// Called when created.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            _transform = transform;
        }

        /// <summary>
        /// Called when enabled.
        /// </summary>
        protected virtual void OnEnable()
        {
            Entities.Add(this);
        }

        /// <summary>
        /// Called when disabled.
        /// </summary>
        protected virtual void OnDisable()
        {
            Entities.Remove(this);
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        protected virtual void Update()
        {
            var dt = Time.deltaTime;

            Stats.DeltaUpdate(dt);
            Agent.DeltaUpdate(dt);
        }

        /// <summary>
        /// Called when entity should die.
        /// </summary>
        protected virtual void Die()
        {
            if (null != OnDeath)
            {
                OnDeath(this);
            }

            Uninitialize();
        }

        /// <summary>
        /// Called when health stat is updated.
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private void Stat_OnHealthUpdated(Stat stat, float oldValue, float newValue)
        {
            if (newValue <= 0f)
            {
                Die();
            }
        }

        /// <summary>
        /// Draws gizmos for help debugging.
        /// </summary>
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
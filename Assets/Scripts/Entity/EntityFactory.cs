using Assets.Scripts.Entity;

namespace Space.Client
{
    public class EntityFactory
    {
        private readonly PoolManager _pools;
        private readonly AIControllerFactory _ai;
        private readonly PhysicsControllerFactory _physics;
        private readonly StatControllerFactory _stats;

        public EntityFactory(
            PoolManager pools,
            AIControllerFactory ai,
            PhysicsControllerFactory physics,
            StatControllerFactory stats)
        {
            _pools = pools;
            _ai = ai;
            _physics = physics;
            _stats = stats;
        }

        public GameEntity Entity(EntityDefinition definition)
        {
            if (null == definition || null == definition.Prefab)
            {
                return null;
            }

            var instance = _pools.Get<GameEntity>(definition.Prefab.gameObject);

            instance.Agent = _ai.AI(definition.AI);
            instance.Model = _physics.Physics(definition.Physics);
            instance.Stats = _stats.Stats(definition.Stats);
            instance.Initialize(definition);

            return instance;
        }
    }
}

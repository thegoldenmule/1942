using Assets.Scripts.Entity;

namespace Space.Client
{
    public class EntityFactory
    {
        private readonly PoolManager _pools;
        private readonly AIControllerFactory _ai;
        private readonly StatControllerFactory _stats;
        private readonly MovementControllerFactory _movements;

        public EntityFactory(
            PoolManager pools,
            AIControllerFactory ai,
            StatControllerFactory stats,
            MovementControllerFactory movements)
        {
            _pools = pools;
            _ai = ai;
            _stats = stats;
            _movements = movements;
        }

        public GameEntity Entity(EntityDefinition definition)
        {
            if (null == definition || null == definition.Prefab)
            {
                return null;
            }

            var instance = _pools.Get<GameEntity>(definition.Prefab.gameObject);

            instance.Agent = _ai.AI(definition.AI);
            instance.Stats = _stats.Stats(definition.Stats);
            instance.Movement = _movements.Movement(definition.Movement);
            instance.Initialize(definition);

            return instance;
        }
    }
}

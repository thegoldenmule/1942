using Assets.Scripts.Entity;

namespace Space.Client
{
    public class EntityFactory
    {
        private readonly PoolManager _pools;
        private readonly AIControllerFactory _ai;
        private readonly StatControllerFactory _stats;
        private readonly ProjectileManager _projectiles;
        
        public EntityFactory(
            PoolManager pools,
            AIControllerFactory ai,
            StatControllerFactory stats,
            ProjectileManager projectiles)
        {
            _pools = pools;
            _ai = ai;
            _stats = stats;
            _projectiles = projectiles;
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
            instance.Weapons = new WeaponController(_projectiles);
            instance.Initialize(definition);

            return instance;
        }
    }
}

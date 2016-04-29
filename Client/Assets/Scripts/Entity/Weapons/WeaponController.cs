namespace Space.Client
{
    public class WeaponController
    {
        public WeaponControllerDefinition Definition { get; private set; }

        private readonly ProjectileManager _projectiles;
        private GameEntity _entity;
        private int _weaponIndex;

        public WeaponController(ProjectileManager projectiles)
        {
            _projectiles = projectiles;
        }

        public void Initialize(GameEntity entity)
        {
            _entity = entity;
            Definition = _entity.Definition.Weapons;
        }

        public void Fire()
        {
            var length = Definition.Weapons.Length;
            if (0 == length)
            {
                return;
            }

            var weapon = Definition.Weapons[_weaponIndex++ % length];
            _projectiles.Fire(_entity, weapon, _entity.transform.position, _entity.transform.forward);
        }
    }
}

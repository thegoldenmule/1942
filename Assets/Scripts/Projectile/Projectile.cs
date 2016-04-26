using Ninject;
using UnityEngine;

namespace Space.Client
{
    public class Projectile : InjectableMonoBehavior
    {
        [Inject]
        public EntityManager Entities { get; private set; }

        public float Speed;

        private GameEntity _source;
        private WeaponDefinition _weapon;
        private Vector3 _start;
        private Vector3 _direction;

        public void Initialize(
            GameEntity source,
            WeaponDefinition weapon,
            Vector3 start,
            Vector3 direction)
        {
            _source = source;
            _weapon = weapon;
            _start = start;
            _direction = direction;

            transform.position = _start;
            transform.forward = _direction;
        }

        public bool DeltaUpdate(float dt)
        {
            var currentPosition = transform.position;
            var nextPosition = currentPosition + _direction * Speed * dt;
            var distance = (nextPosition - currentPosition).magnitude;

            transform.position = nextPosition;

            // check for collisions
            var ray = new Ray(currentPosition, nextPosition);
            var entities = Entities.Entities;
            for (int i = 0, len = entities.Count; i < len; i++)
            {
                var entity = entities[i];
                if (entity == _source)
                {
                    continue;
                }

                var localBounds = entity.Definition.Bounds;
                var bounds = new Bounds(
                    entity.transform.position + localBounds.center,
                    localBounds.size);

                float intersectionDistance;
                if (bounds.IntersectRay(ray, out intersectionDistance)
                    && intersectionDistance < distance)
                {
                    Debug.Log("Collision!");

                    entity.Stats.Stat(StatType.Health).Value -= _source.Stats.Stat(StatType.DamageModifier).Value * _weapon.Damage;

                    return false;
                }
            }

            return true;
        }
    }
}
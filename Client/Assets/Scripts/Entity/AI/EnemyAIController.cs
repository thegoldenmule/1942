using System;
using UnityEngine;

namespace Space.Client
{
    public class EnemyAIController : AIController
    {
        private GameEntity _entity;
        private AIControllerDefinition _definition;

        private DateTime _lastFireTime;

        public override void Initialize(GameEntity entity)
        {
            _entity = entity;
            _definition = entity.Definition.AI;

            _lastFireTime = DateTime.Now;
        }

        public override void DeltaUpdate(float dt)
        {
            base.DeltaUpdate(dt);

            _entity.transform.position += Vector3.back * _entity.Stats.Stat(StatType.Speed).Value * dt;

            var now = DateTime.Now;
            if (now.Subtract(_lastFireTime).TotalSeconds > _definition.AttackSpeedSeconds)
            {
                _lastFireTime = DateTime.Now;
                _entity.Weapons.Fire();
            }
        }
    }
}
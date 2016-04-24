using UnityEngine;

namespace Space.Client
{
    public class EnemyAIController : AIController
    {
        private GameEntity _entity;
        private AIControllerDefinition _definition;
        private float _elapsedSeconds = 0f;

        public override void Initialize(GameEntity entity)
        {
            _entity = entity;
            _definition = entity.Definition.AI;
        }

        public override void DeltaUpdate(float dt)
        {
            base.DeltaUpdate(dt);

            var nextSeconds = _elapsedSeconds + dt;

            for (int i = 0, len = _definition.Attacks.Length; i < len; i++)
            {
                var attack = _definition.Attacks[i];
                if (_elapsedSeconds < attack.Time
                    && (nextSeconds > attack.Time || Mathf.Approximately(nextSeconds, attack.Time)))
                {
                    OnAttackEvent(attack);
                }
            }

            for (int i = 0, len = _definition.Translations.Length; i < len; i++)
            {
                var translation = _definition.Translations[i];
                if (_elapsedSeconds < translation.Time
                    && (nextSeconds > translation.Time || Mathf.Approximately(nextSeconds, translation.Time)))
                {
                    OnTranslationEvent(translation);
                }
            }

            _elapsedSeconds = nextSeconds;
        }

        private void OnAttackEvent(AttackEvent @event)
        {
            
        }

        private void OnTranslationEvent(TranslationEvent @event)
        {
            
        }
    }
}

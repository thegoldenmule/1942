using System.Collections.Generic;

namespace Space.Client
{
    public enum StatType
    {
        Health,
        Speed,
        Damage
    }

    public class StatController
    {
        private readonly List<Stat> _stats = new List<Stat>(); 

        private GameEntity _entity;
        private StatControllerDefinition _definition;

        public void Initialize(GameEntity entity)
        {
            _entity = entity;
            _definition = _entity.Definition.Stats;

            foreach (var definition in _definition.Stats)
            {
                _stats.Add(new Stat(definition));
            }
        }

        public void DeltaUpdate(float dt)
        {
            //
        }

        public Stat Stat(StatType type)
        {
            for (int i = 0, len = _stats.Count; i < len; i++)
            {
                if (_stats[i].Definition.Type == type)
                {
                    return _stats[i];
                }
            }

            return null;
        }
    }
}

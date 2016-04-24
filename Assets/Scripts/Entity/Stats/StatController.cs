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
        private GameEntity _entity;
        private StatControllerDefinition _definition;

        public void Initialize(GameEntity entity)
        {
            _entity = entity;
            _definition = _entity.Definition.Stats;
        }

        public Stat Stat(StatType type)
        {
            for (int i = 0, len = _definition.Stats.Count; i < len; i++)
            {
                if (_definition.Stats[i].Type == type)
                {
                    return _definition.Stats[i];
                }
            }

            var stat = new Stat
            {
                Type = type
            };
            _definition.Stats.Add(stat);

            return stat;
        }
    }
}

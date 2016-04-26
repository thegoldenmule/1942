namespace Space.Client
{
    public class Stat
    {
        private readonly StatDefinition _definition;

        public StatDefinition Definition
        {
            get { return _definition; }
        }

        public float Initial
        {
            get { return _definition.Value; }
        }

        public float Value { get; set; }

        public Stat(StatDefinition definition)
        {
            _definition = definition;

            Value = _definition.Value;
        }
    }
}
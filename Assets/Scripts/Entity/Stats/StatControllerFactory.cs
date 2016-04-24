namespace Space.Client
{
    public class StatControllerFactory
    {
        public StatController Stats(StatControllerDefinition definition)
        {
            return new StatController();
        }
    }
}
namespace Space.Client
{
    public class MovementControllerFactory
    {
        public MovementController Movement(MovementControllerDefinition definition)
        {
            return new MovementController();
        }
    }
}
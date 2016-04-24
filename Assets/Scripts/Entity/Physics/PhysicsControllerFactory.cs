namespace Space.Client
{
    public class PhysicsControllerFactory
    {
        public PhysicsController Physics(PhysicsControllerDefinition definition)
        {
            return new PhysicsController();
        }
    }
}
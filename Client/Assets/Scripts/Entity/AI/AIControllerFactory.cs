using Space.Client;

namespace Assets.Scripts.Entity
{
    public class AIControllerFactory
    {
        public AIController AI(AIControllerDefinition definition)
        {
            switch (definition.Type)
            {
                case AIControllerDefinition.AIType.Enemy:
                {
                    return new EnemyAIController();
                }
                case AIControllerDefinition.AIType.Null:
                {
                    return new NullAIController();
                }
            }

            return null;
        }
    }
}
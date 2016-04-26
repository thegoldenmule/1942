namespace Space.Client
{
    public class EnemyAIController : AIController
    {
        private GameEntity _entity;
        private AIControllerDefinition _definition;
        
        public override void Initialize(GameEntity entity)
        {
            _entity = entity;
            _definition = entity.Definition.AI;
        }

        public override void DeltaUpdate(float dt)
        {
            base.DeltaUpdate(dt);

            
        }
    }
}
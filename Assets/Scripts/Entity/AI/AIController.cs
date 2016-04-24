using System;

namespace Space.Client
{
    [Serializable]
    public class AIController
    {
        protected readonly StateMachine _fsm = new StateMachine();

        public virtual void Initialize(GameEntity entity)
        {
            
        }

        public virtual void DeltaUpdate(float dt)
        {
            
        }
    }
}
namespace Space.Client
{
    public class GameState : InjectableMonoBehavior, IState
    {
        public GameState Next;
        public GameState Failure;

        public virtual void Enter()
        {
            
        }

        public virtual void DeltaUpdate(float dt)
        {
            
        }

        public virtual IAsyncToken<IState> Exit()
        {
            return new AsyncToken<IState>(this);
        }
    }
}

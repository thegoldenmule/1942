namespace Space.Client
{
    public class InputState : InjectableMonoBehavior, IState
    {
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
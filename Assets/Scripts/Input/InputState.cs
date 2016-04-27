namespace Space.Client
{
    /// <summary>
    /// State for input.
    /// </summary>
    public class InputState : InjectableMonoBehavior, IState
    {
        /// <summary>
        /// Called when state is entered.
        /// </summary>
        public virtual void Enter()
        {
            
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        /// <param name="dt"></param>
        public virtual void DeltaUpdate(float dt)
        {
            
        }

        /// <summary>
        /// Called when state is exited.
        /// </summary>
        /// <returns></returns>
        public virtual IAsyncToken<IState> Exit()
        {
            return new AsyncToken<IState>(this);
        }
    }
}
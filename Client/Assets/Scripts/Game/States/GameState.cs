using Ninject;

namespace Space.Client
{
    /// <summary>
    /// Implementation of IState on monobehaviour.
    /// </summary>
    public class GameState : InjectableMonoBehavior, IState
    {
        /// <summary>
        /// Dependencies.
        /// </summary>
        [Inject]
        public GameStateController States { get; private set; }

        /// <summary>
        /// States.
        /// </summary>
        public GameState Next;
        public GameState Failure;

        /// <summary>
        /// Called when state has been entered.
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

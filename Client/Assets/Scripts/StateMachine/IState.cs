namespace Space
{
    /// <summary>
    /// Implementation of a state.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Called when the state is entered.
        /// </summary>
        void Enter();

        /// <summary>
        /// Called every frame.
        /// </summary>
        /// <param name="dt"></param>
        void DeltaUpdate(float dt);

        /// <summary>
        /// Async exit function.
        /// </summary>
        /// <returns></returns>
        IAsyncToken<IState> Exit();
    }
}
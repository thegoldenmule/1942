namespace Space
{
    /// <summary>
    /// Implementation of a state machine.
    /// </summary>
    public interface IStateMachine
    {
        /// <summary>
        /// Gets and sets the current state.
        /// </summary>
        IState State { get; set; }

        /// <summary>
        /// Called every frame.
        /// </summary>
        /// <param name="dt"></param>
        void DeltaUpdate(float dt);
    }
}
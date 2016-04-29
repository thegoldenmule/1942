using Ninject;
using UnityEngine.UI;

namespace Space.Client
{
    /// <summary>
    /// Last state of the game.
    /// </summary>
    public class EndGameState : GameState
    {
        /// <summary>
        /// Dependencies.
        /// </summary>
        [Inject]
        public GameStateController States { get; private set; }

        /// <summary>
        /// Text gameobject.
        /// </summary>
        public Text Text;

        /// <summary>
        /// Restarts button.
        /// </summary>
        public Button Restart;

        /// <summary>
        /// Called when state is entered.
        /// </summary>
        public override void Enter()
        {
            base.Enter();

            gameObject.SetActive(true);
        }

        /// <summary>
        /// Called when state is exited.
        /// </summary>
        /// <returns></returns>
        public override IAsyncToken<IState> Exit()
        {
            gameObject.SetActive(false);

            return base.Exit();
        }

        /// <summary>
        /// Restarts end game state.
        /// </summary>
        public void OnRestart()
        {
            States.State = States.Combat;
        }
    }
}
using UnityEngine.UI;

namespace Space.Client
{
    /// <summary>
    /// Called When game is over.
    /// </summary>
    public class GameOverState : GameState
    {
        /// <summary>
        /// Text gameobject.
        /// </summary>
        public Text Text;

        /// <summary>
        /// Called when state is entered.
        /// </summary>
        public override void Enter()
        {
            base.Enter();

            Text.enabled = true;
        }

        /// <summary>
        /// Called when state is exited.
        /// </summary>
        /// <returns></returns>
        public override IAsyncToken<IState> Exit()
        {
            Text.enabled = false;

            return base.Exit();
        }
    }
}
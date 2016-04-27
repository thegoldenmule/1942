using UnityEngine.UI;

namespace Space.Client
{
    public class EndGameState : GameState
    {
        public Text Text;

        public override void Enter()
        {
            base.Enter();

            Text.enabled = true;
        }

        public override IAsyncToken<IState> Exit()
        {
            Text.enabled = false;

            return base.Exit();
        }
    }
}
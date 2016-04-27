using System;
using UnityEngine.UI;

namespace Space.Client
{
    public class SplashState : GameState
    {
        public Text Text;
        public float Seconds = 3;

        private DateTime _enterTime;

        public override void Enter()
        {
            base.Enter();

            Text.enabled = true;

            _enterTime = DateTime.Now;
        }

        public override void DeltaUpdate(float dt)
        {
            base.DeltaUpdate(dt);

            if (DateTime.Now.Subtract(_enterTime).TotalSeconds > Seconds)
            {
                States.State = Next;
            }
        }

        public override IAsyncToken<IState> Exit()
        {
            Text.enabled = false;

            return base.Exit();
        }
    }
}
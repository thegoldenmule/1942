using System;
using UnityEngine.UI;

namespace Space.Client
{
    /// <summary>
    /// First state of the game.
    /// </summary>
    public class SplashState : GameState
    {
        /// <summary>
        /// Text game object.
        /// </summary>
        public Text Text;

        /// <summary>
        /// Seconds to wait.
        /// </summary>
        public float Seconds = 3;

        /// <summary>
        /// Time at which state was entered.
        /// </summary>
        private DateTime _enterTime;

        /// <summary>
        /// Called when state has been entered.
        /// </summary>
        public override void Enter()
        {
            base.Enter();

            Text.enabled = true;

            _enterTime = DateTime.Now;
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        /// <param name="dt"></param>
        public override void DeltaUpdate(float dt)
        {
            base.DeltaUpdate(dt);

            if (DateTime.Now.Subtract(_enterTime).TotalSeconds > Seconds)
            {
                States.State = Next;
            }
        }

        /// <summary>
        /// Called when state has been exited.
        /// </summary>
        /// <returns></returns>
        public override IAsyncToken<IState> Exit()
        {
            Text.enabled = false;

            return base.Exit();
        }
    }
}
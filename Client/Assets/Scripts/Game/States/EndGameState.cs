using System;
using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// Last state of the game.
    /// </summary>
    public class EndGameState : GameState
    {
        /// <summary>
        /// Called when state is entered.
        /// </summary>
        public override void Enter()
        {
            enabled = true;

            base.Enter();
        }

        /// <summary>
        /// Called when state is exited.
        /// </summary>
        /// <returns></returns>
        public override IAsyncToken<IState> Exit()
        {
            enabled = false;

            return base.Exit();
        }

        /// <summary>
        /// Draws controls.
        /// </summary>
        private void OnGUI()
        {
            GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical(GUILayout.Width(200));

            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Restart", GUILayout.Width(100), GUILayout.Height(40)))
            {
                States.State = Next;
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
    }
}
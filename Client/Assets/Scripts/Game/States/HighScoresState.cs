using System;
using Ninject;
using Space.Common;
using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// State that shows high scores.
    /// </summary>
    public class HighScoresState : GameState
    {
        /// <summary>
        /// Service for getting/setting high scores.
        /// </summary>
        [Inject]
        public HighScoreService HighScores { get; private set; }

        /// <summary>
        /// How often we poll high scores.
        /// </summary>
        public int PollSeconds = 5;

        /// <summary>
        /// Token for retrieving scores.
        /// </summary>
        private IAsyncToken<HighScores> _scoresToken;

        /// <summary>
        /// Time we sent the last request.
        /// </summary>
        private DateTime _requestTime;

        /// <summary>
        /// Called when state has been entered.
        /// </summary>
        public override void Enter()
        {
            base.Enter();

            Poll();

            enabled = true;
        }

        /// <summary>
        /// Called when state has been exited.
        /// </summary>
        /// <returns></returns>
        public override IAsyncToken<IState> Exit()
        {
            if (null != _scoresToken)
            {
                _scoresToken.Abort();
                _scoresToken = null;
            }

            enabled = false;

            return base.Exit();
        }

        /// <summary>
        /// Draws High Score controls.
        /// </summary>
        private void OnGUI()
        {
            GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical(GUILayout.Width(200));

            if (DateTime.Now.Subtract(_requestTime).TotalSeconds > PollSeconds)
            {
                Poll();
            }

            if (null != _scoresToken && _scoresToken.IsReady)
            {
                if (_scoresToken.Success)
                {
                    var scores = _scoresToken.Value.Scores;
                    if (0 == scores.Count)
                    {
                        Center("No high scores!");
                    }
                    else
                    {
                        Center("High Scores");
                        foreach (var score in scores)
                        {
                            Center(score.ToString());
                        }
                    }
                }
                else
                {
                    Center(string.Format(
                        "Could not retrieve high scores : {0}.",
                        _scoresToken.Exception));
                }
            }
            else
            {
                Center("Loading high scores...");
            }

            if (GUILayout.Button("Play!",
                GUILayout.Width(100),
                GUILayout.Height(40)))
            {
                States.State = Next;
            }

            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        /// <summary>
        /// Centers a label.
        /// </summary>
        /// <param name="label"></param>
        private void Center(string label)
        {
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            GUILayout.FlexibleSpace();

            GUILayout.Label(label);

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        /// <summary>
        /// Polls high score service.
        /// </summary>
        private void Poll()
        {
            if (null != _scoresToken)
            {
                _scoresToken.Abort();
            }

            _scoresToken = HighScores.GetHighScores();
            _requestTime = DateTime.Now;
        }
    }
}
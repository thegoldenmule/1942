using Ninject;
using Space.Server;
using UnityEngine;

namespace Space.Client
{
    public class HighScoresState : GameState
    {
        [Inject]
        public HighScoreService HighScores { get; private set; }

        private IAsyncToken<HighScores> _scoresToken;

        public override void Enter()
        {
            base.Enter();

            _scoresToken = HighScores.GetHighScores();
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical(GUILayout.Width(200));



            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
    }
}
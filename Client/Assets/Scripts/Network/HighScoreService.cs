using System;
using System.Collections;
using System.Text;
using Newtonsoft.Json;
using Space.Common;
using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// Service that retrieves high scores.
    /// </summary>
    public class HighScoreService : MonoBehaviour
    {
        /// <summary>
        /// Base URL for high score API.
        /// </summary>
        private readonly string _baseUrl = "http://localhost";

        /// <summary>
        /// Retrieves high scores.
        /// </summary>
        /// <returns></returns>
        public IAsyncToken<HighScores> GetHighScores()
        {
            var url = _baseUrl + "/highscore";
            
            Debug.Log("GET " + url);

            var token = new AsyncToken<HighScores>();

            var request = new WWW(url);
            StartCoroutine(Load(request, () =>
            {
                if (!string.IsNullOrEmpty(request.error))
                {
                    token.Fail(new Exception(request.error));
                }
                else
                {
                    token.Succeed(JsonConvert.DeserializeObject<HighScores>(request.text));
                }
            }));

            return token;
        }

        /// <summary>
        /// Posts a new high score.
        /// </summary>
        /// <param name="score"></param>
        public void PostHighScore(int score)
        {
            var url = _baseUrl + "/sethighscore?Score=" + score;

            Debug.Log("GET " + url);

            var request = new WWW(url);
            
            StartCoroutine(Load(request, () =>
            {
                if (!string.IsNullOrEmpty(request.error))
                {
                    Debug.LogError("Could not set : " + request.error);
                }
                else
                {
                    Debug.Log("Successfully posted high score.");
                }
            }));
        }

        /// <summary>
        /// Waits on a WWW request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        private IEnumerator Load(WWW request, Action callback)
        {
            yield return request;

            callback();
        }
    }
}
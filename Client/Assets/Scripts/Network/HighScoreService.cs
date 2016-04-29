using System;
using System.Collections;
using System.Text;
using Newtonsoft.Json;
using Space.Server;
using UnityEngine;

namespace Space.Client
{
    public class HighScoreService : MonoBehaviour
    {
        private readonly string _baseUrl = "http://localhost";

        public IAsyncToken<HighScores> GetHighScores()
        {
            var url = _baseUrl + "/highscores";
            
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

        public void PostHighScore(int score)
        {
            var url = _baseUrl + "/highscores";

            Debug.Log("POST " + url);

            var request = new WWW(
                url,
                Encoding.UTF8.GetBytes(string.Format("score={0}", score)));
            
            StartCoroutine(Load(request, () =>
            {
                if (!string.IsNullOrEmpty(request.error))
                {
                    Debug.LogError("Could not post : " + request.error);
                }
                else
                {
                    Debug.Log("Successfully posted high score.");
                }
            }));
        }

        private IEnumerator Load(WWW request, Action callback)
        {
            yield return request;

            callback();
        }
    }
}
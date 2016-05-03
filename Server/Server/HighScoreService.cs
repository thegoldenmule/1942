using System.IO;
using Nancy;
using Newtonsoft.Json;
using Space.Common;

namespace Space.Server
{
    /// <summary>
    /// Service for getting/setting high scores.
    /// 
    /// TODO: High score lists would likely be stored in Redis or another
    /// TODO: in-memory store, not flat-files.
    /// </summary>
    public class HighScoreService : NancyModule
    {
        /// <summary>
        /// Path to write high scores to.
        /// </summary>
        private const string PATH = "HighScores.json";

        /// <summary>
        /// Cached high scores.
        /// </summary>
        public HighScores Scores;

        /// <summary>
        /// Constructor.
        /// </summary>
        public HighScoreService()
        {
            Get["/highscore"] = _ =>
            {
                if (null == Scores)
                {
                    Scores = Read();
                }

                return JsonConvert.SerializeObject(Scores);
            };

            Post["/highscore"] = parameters =>
            {
                var score = parameters.Score;

                if (null == Scores)
                {
                    Scores = Read();
                }

                for (int i = 0, len = Scores.Scores.Count; i < len; i++)
                {
                    if (Scores.Scores[i] > score)
                    {
                        Scores.Scores.Insert(i, score);
                    }
                }

                Write(Scores);

                return "Ok.";
            };
        }

        /// <summary>
        /// Writes high scores.
        /// </summary>
        /// <param name="scores"></param>
        private static void Write(HighScores scores)
        {
            var value = JsonConvert.SerializeObject(scores);

            File.WriteAllText(PATH, value);
        }

        /// <summary>
        /// Reads high scores.
        /// </summary>
        /// <returns></returns>
        private static HighScores Read()
        {
            if (!File.Exists(PATH))
            {
                var scores = new HighScores();

                Write(scores);

                return scores;
            }

            var value = File.ReadAllText(PATH);
            return JsonConvert.DeserializeObject<HighScores>(value);
        }
    }
}
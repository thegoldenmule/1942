using System;
using System.IO;
using Nancy;
using Nancy.Hosting.Self;
using Newtonsoft.Json;

namespace Space.Server
{
    public class HighScoreService : NancyModule
    {
        private const string PATH = "HighScores.json";

        public HighScores Scores;

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

        private static void Write(HighScores scores)
        {
            var value = JsonConvert.SerializeObject(scores);

            File.WriteAllText(PATH, value);
        }

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

    public class HighScoreServer
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(
                new Uri("http://localhost:80/nancy/"),
                new DefaultNancyBootstrapper(),
                new HostConfiguration
                {
                    UrlReservations = new UrlReservations
                    {
                        CreateAutomatically = true
                    }
                }))
            {
                host.Start();

                Console.Write("Listening on port 80.");

                while (true)
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
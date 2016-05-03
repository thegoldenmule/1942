using System;
using Nancy;
using Nancy.Hosting.Self;

namespace Space.Server
{
    /// <summary>
    /// REST server for high scores.
    /// </summary>
    public class HighScoreServer
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            using (var host = new NancyHost(
                new Uri("http://localhost:80/"),
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
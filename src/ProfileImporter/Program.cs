using System;
using System.IO;
using Common;
using Common.Overwatch;
using Microsoft.Extensions.Logging;

namespace ProfileImporter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ApplicationLogging.LoggerFactory.AddConsole();
            var logger = ApplicationLogging.CreateLogger<Program>();

            var importer = new Importer(SettingsManager.ApplicationSettings.ServerPath);

            foreach (var p in SettingsManager.ApplicationSettings.Profiles)
            {
                Console.WriteLine("Fetching profile " + p);
                try
                {
                    var task = importer.ImportAndSaveProfileToCacheAsync(p);
                    task.Wait();
                }
                catch (Exception ex)
                {
                    logger.LogError(new EventId(ApplicationLogging.ImportEvent), string.Format("Failed to import profile {0}. Error: {1}", p, ex.Message));
                }
            }

            // Debug / code can be remove for production...

            var dateDirs = Directory.GetDirectories(SettingsManager.ApplicationSettings.SaveLocation);
            foreach (var dir in dateDirs)
            {
                var date = new DateTime(Convert.ToInt64(Path.GetFileName(dir)));

                foreach (var p in SettingsManager.ApplicationSettings.Profiles)
                {
                    var filename = dir + Path.DirectorySeparatorChar + p.Replace('#', '-') + ".html";
                    if (File.Exists(filename))
                    {
                        var snapshot = new PlayerSnapshot(File.ReadAllText(filename));
                        snapshot.ParseHtml();
                        logger.LogInformation(new EventId(ApplicationLogging.ImportEvent), "{0} has won {1} games as of {2}", p, snapshot.GamesWon, date.ToString("D"));
                        logger.LogInformation(snapshot.PlayerIcon.ToString());
                    }

                }
            }

            Console.WriteLine("Completed fetching profiles.");
        }
    }
}

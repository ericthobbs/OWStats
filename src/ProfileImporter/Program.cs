using System;
using System.Threading.Tasks;
using Common;
using Microsoft.Extensions.Logging;

namespace ProfileImporter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Common.ApplicationLogging.LoggerFactory.AddConsole();

            var importer = new Importer(SettingsManager.ApplicationSettings.ServerPath);

            foreach (var p in SettingsManager.ApplicationSettings.Profiles)
            {
                Console.WriteLine("Fetching profile " + p);
                var task = importer.ImportProfileAsync(p);
                task.Wait();
            }
            Console.WriteLine("Completed fetching profiles.");
        }
    }
}

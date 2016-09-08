using System;
using System.Threading.Tasks;

namespace ProfileImporter
{
    public class Program
    {
        public static void Main(string[] args)
        {
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

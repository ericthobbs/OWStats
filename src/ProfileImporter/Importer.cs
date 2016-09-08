using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ProfileImporter
{
    public class Importer
    {
        private static ILogger Logger => ApplicationLogging.CreateLogger<Importer>();

        private System.Net.Http.HttpClient HttpClient { get; set; }

        public Importer(string basePath)
        {
            HttpClient = new System.Net.Http.HttpClient
            {
                BaseAddress = new Uri(basePath),
            };
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(SettingsManager.ApplicationSettings.UserAgent);
        }

        public async Task<bool> ImportProfileAsync(string name)
        {
            //normalize name
            var battleTag = BattleNetProfile.ParseTag(name);

            //Get the save location.
            var importPath = SettingsManager.ApplicationSettings.SaveLocation;
            var date = DateTime.Now.Date;
            importPath += date.Ticks + @"\";
            System.IO.Directory.CreateDirectory(importPath);

            importPath += battleTag + ".html";

            Logger.LogInformation(new EventId(ApplicationLogging.ImportEvent), string.Format("Caching profile to {0}", importPath));

            if (!System.IO.File.Exists(importPath.Replace('#', '-')))
            {
                var data = await HttpClient.GetStringAsync(battleTag.ToString().Replace('#', '-'));

                System.IO.File.WriteAllText(importPath.Replace('#', '-'), data);
            }

            return true;
        }
    }
}

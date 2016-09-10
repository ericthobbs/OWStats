using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Common;
using Common.Overwatch;

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

        public async Task<Common.Overwatch.PlayerSnapshot> FetchPlayerSnapshotAsync(BattleNetProfile player)
        {
            Logger.LogDebug("Getting profile {0} from server {1}", player, HttpClient.BaseAddress);
            var response = await HttpClient.GetAsync(player.ToString());

            if (!response.IsSuccessStatusCode)
            {
                Logger.LogError(new EventId(ApplicationLogging.ImportEvent), 
                    "Failed to capture profile. Error: " + response.StatusCode + ": " + response.ReasonPhrase);
                return null;
            }

            return new PlayerSnapshot(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Debug Method.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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
            else
            {
                Logger.LogInformation(new EventId(ApplicationLogging.ImportEvent), "Skipping profile import - already cached.");
            }

            return true;
        }
    }
}

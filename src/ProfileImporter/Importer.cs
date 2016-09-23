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

        public string CacheDirectory { get; set; }

        public Importer(string basePath)
        {
            HttpClient = new System.Net.Http.HttpClient
            {
                BaseAddress = new Uri(basePath),
            };

            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(SettingsManager.ApplicationSettings.UserAgent);
            CacheDirectory = SettingsManager.ApplicationSettings.SaveLocation;
        }

        public async Task<PlayerSnapshot> FetchPlayerSnapshotAsync(BattleNetProfile player)
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

        public async Task<bool> ProfileIsUpdatable(BattleNetProfile profile)
        {
            //Temp

            //Check if the file exists, if it does not - profile is updatable.
            //If it does exist, check timestamp

            return await Task.Run(() => true);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile">BattleNet Profile.</param>
        /// <param name="datetime">Date of the cache file.</param>
        /// <returns></returns>
        private string GetProfileCacheFile(BattleNetProfile profile, DateTime datetime)
        {
            var importPath = CacheDirectory;
            importPath += datetime.Date.Ticks + @"\";
            System.IO.Directory.CreateDirectory(importPath);

            importPath += profile + ".html";

            return importPath.Replace('#', '-');
        }

        /// <summary>
        /// Debug Method.
        /// </summary>
        /// <param name="profileName"></param>
        /// <returns></returns>
        public async Task<bool> ImportAndSaveProfileToCacheAsync(BattleNetProfile profileName)
        {
            //Get the save location.
            var importPath = GetProfileCacheFile(profileName, DateTime.Now);

            Logger.LogInformation(new EventId(ApplicationLogging.ImportEvent), string.Format("Caching profile to {0}", importPath));

            //!System.IO.File.Exists(importPath)
            if (await ProfileIsUpdatable(profileName))
            {
                var data = await HttpClient.GetStringAsync(profileName.ToString().Replace('#', '-'));

                System.IO.File.WriteAllText(importPath, data);
            }
            else
            {
                Logger.LogInformation(new EventId(ApplicationLogging.ImportEvent), "Skipping profile import - already cached.");
            }

            return true;
        }
    }
}

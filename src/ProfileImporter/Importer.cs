using System;

namespace ProfileImporter
{
    public class Importer
    {

        private System.Net.Http.HttpClient HttpClient { get; set; }

        public Importer(string basePath)
        {
            HttpClient = new System.Net.Http.HttpClient
            {
                BaseAddress = new Uri(basePath),
            };
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(SettingsManager.ApplicationSettings.UserAgent);
        }

        public async void ImportProfileAsync(string name)
        {
            //Get the save location.
            var importPath = SettingsManager.ApplicationSettings.SaveLocation;

            //normalize name
            var battleTag = BattleNetProfile.ParseTag(name);



            int a = 0;
        }
    }
}

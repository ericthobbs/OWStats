using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ProfileImporter
{
    public class SettingsManager
    {
        private static ILogger Logger => ApplicationLogging.CreateLogger<SettingsManager>();

        public static ApplicationSettings ApplicationSettings { get; private set; }

        static SettingsManager()
        {
            LoadGlobalSettings();
        }

        public static void LoadGlobalSettings()
        {
            try
            {
                ApplicationSettings =
                    JsonConvert.DeserializeObject<ApplicationSettings>(File.ReadAllText("settings.json"));
            }
            catch (Exception ex)
            {
                Logger.LogWarning(new EventId(ApplicationLogging.SettingsEvent), ex,"Failed to load settings.json");
            }
        }
    }
}

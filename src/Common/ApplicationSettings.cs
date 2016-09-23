using System.Collections.Generic;

namespace Common
{

    /// <summary>
    /// Strongly typed application settings.
    /// </summary>
    public class ApplicationSettings
    {
        /// <summary>
        /// Location to save the downloaded/cached raw html snapshots
        /// </summary>
        public string SaveLocation { get; set; }

        /// <summary>
        /// Where to get the profile html data
        /// </summary>
        public string ServerPath { get; set; }

        /// <summary>
        /// User-Agent of the scrapper
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// List of BattleNet profiles to gather/track stats of automatically
        /// </summary>
        public List<string> Profiles { get; set; }

        /// <summary>
        /// Minimum cache time
        /// </summary>
        public int MinCacheTime { get; set; }

        public int MaxScrapperThreads { get; set; }

        /// <summary>
        /// Database connection string
        /// </summary>
        public string DbConnection { get; set; }
    }
}

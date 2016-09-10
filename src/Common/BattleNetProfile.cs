using System;
using Microsoft.Extensions.Logging;

namespace Common
{
    /// <summary>
    /// Battle.Net Profile
    /// </summary>
    public class BattleNetProfile
    {
        private static ILogger Logger => Common.ApplicationLogging.CreateLogger<BattleNetProfile>();

        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unique Identifier
        /// </summary>
        public string Tag { get; set; }

        public override string ToString()
        {
            return string.Format("{0}#{1}", Name, Tag);
        }

        /// <summary>
        /// Parses a BattleNet Tag into its components
        /// </summary>
        /// <param name="bnetname">Tag#1234</param>
        /// <returns>Parsed Battle.Net Tag</returns>
        public static BattleNetProfile ParseTag(string bnetname)
        {
            if (string.IsNullOrEmpty(bnetname))
            {
                throw new ArgumentNullException(nameof(bnetname));
            }

            var parts = bnetname.Split(new char[] {'#', '-', '_'}, StringSplitOptions.RemoveEmptyEntries);

            if(parts.Length != 2)
                throw new ArgumentException(nameof(bnetname));

            return new BattleNetProfile() {Name = parts[0], Tag = parts[1]};
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common.Attributes;
using Microsoft.Extensions.Logging;

namespace Common.Overwatch
{
    public class PlayerSnapshot
    {

        public int GamesWon { get; private set; }
        public Uri PlayerIcon { get; private set; }

        public string RawHtml { get; private set; }

        private static ILogger Logger => Common.ApplicationLogging.CreateLogger<PlayerSnapshot>();

        private HtmlAgilityPack.HtmlDocument Document { get; set; }

        public PlayerSnapshot(string html)
        {
            RawHtml = html;
        }

        public bool ParseHtml()
        {
            Document = new HtmlAgilityPack.HtmlDocument();
            Document.LoadHtml(RawHtml);

            var quickPlayNode = Document.DocumentNode.SelectSingleNode("//div[@id='quick-play']");

            var competitiveNode = Document.DocumentNode.SelectSingleNode("//div[@id='competitive-play']");

            GetGamesWon();
            GetPlayerIconUrl();

            var compareTypesQp = EnumerateHeroComparisonTypes(quickPlayNode);

            //Demo - this needs to be moved into its own method that can be used for both qp and cm modes.
            foreach (var type in compareTypesQp)
            {
                var heroCompareType = GetTypeWithGuid(this.GetType().GetTypeInfo().Assembly, type.Item2);

                var instance = Activator.CreateInstance(heroCompareType, "Phara", "123", "http://localhost/web123.png");
                
                

                int a = 0;
            }

            //....see note above
            var compareTypesCm = EnumerateHeroComparisonTypes(competitiveNode);

            return true;
        }

        private List<Tuple<string,string>> EnumerateHeroComparisonTypes(HtmlAgilityPack.HtmlNode rootNode)
        {
            var types = new List<Tuple<string,string>>();

            var selectNode = rootNode.SelectSingleNode("//select[@data-group-id='comparisons']");

            foreach (var optionNode in selectNode.ChildNodes)
            {
                if (optionNode.Name == "option")
                {
                    var item = new Tuple<string, string>(
                        optionNode.GetAttributeValue("option-id", string.Empty),
                        optionNode.GetAttributeValue("value", string.Empty));
                    types.Add(item);
                }
            }

            return types;
        }

        private void GetPlayerIconUrl()
        {
            try
            {
                var imgTag = Document.DocumentNode.SelectSingleNode("//img[@class='player-portrait']");
                var url = imgTag.GetAttributeValue("src", string.Empty);
                if (!string.IsNullOrEmpty(url))
                {
                    PlayerIcon = new Uri(url);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to get player icon.");
            }
        }


        private void GetGamesWon()
        {
            try
            {
                var header = Document.DocumentNode.SelectSingleNode("//div[@class='masthead']");
                var searchSpans = header.SelectNodes("//span");
                foreach (var span in searchSpans)
                {
                    if (span.InnerText.Contains("games won"))
                    {
                        var gamesNodeText = span.InnerText.Replace(" games won", string.Empty).Trim();
                        GamesWon = Convert.ToInt32(gamesNodeText);
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(new EventId(ApplicationLogging.SnapShowParseError), "Failed to parse games won count.");
            }
        }

        //Hacky
        static Type GetTypeWithGuid(Assembly assembly, string blizzardguid)
        {
            foreach (Type type in assembly.GetTypes())
            {
                foreach (var item in type.GetTypeInfo().GetCustomAttributes(typeof (BlizzardGuidAttribute), true))
                {
                    if (item is BlizzardGuidAttribute)
                    {
                        if ((item as BlizzardGuidAttribute).BlizzardGuid == blizzardguid)
                            return type;
                    }
                }
            }
            Logger.LogError("Failed to locate requested type {0}", blizzardguid);
            return null;
        }
    }
}

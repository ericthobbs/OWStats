using System;
using Common;
using Xunit;

namespace Importer.Tests
{
    public class BattleNetProfileTests
    {
        [Theory]
        [InlineData("RavenKnight", "1137")]
        [InlineData("Nugsly", "1837")]
        [InlineData("LoadedDice", "1534")]
        public void ValidBattleNetTag(string playername, string tag)
        {
            var profile = BattleNetProfile.ParseTag(string.Format("{0}#{1}", playername, tag));

            Assert.Equal(playername, profile.Name);
            Assert.Equal(tag, profile.Tag);
        }

        [Fact]
        public void InvalidBattleTagName()
        {
            Assert.Throws<ArgumentException>(() => BattleNetProfile.ParseTag("#1137"));
        }

        [Fact]
        public void InvalidBattleTagTag()
        {
            Assert.Throws<ArgumentException>(() => BattleNetProfile.ParseTag("RavenKnight#"));
        }

        [Fact]
        public void InvalidBattleTagPartialName()
        {
            Assert.Throws<ArgumentException>(() => BattleNetProfile.ParseTag("RavenKnight"));
        }

        [Fact]
        public void InvalidBattleTagSep()
        {
            Assert.Throws<ArgumentException>(() => BattleNetProfile.ParseTag("RavenKnight_1137"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Attributes;

namespace Common.Overwatch.HeroComparison
{
    [BlizzardGuid("overwatch.guid.0x0860000000000039")]
    public class HeroGamesWon : HeroCompareBase
    {
        public HeroGamesWon(string charactername, string length, string characterporturl)
            : base(charactername, length, characterporturl) { }
    }
}

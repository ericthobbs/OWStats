using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Attributes;

namespace Common.Overwatch.HeroComparison
{
    [BlizzardGuid("overwatch.guid.0x086000000000039C")]
    public class HeroObjectiveKillsAverage : HeroCompareBase
    {
        public HeroObjectiveKillsAverage(string charactername, string length, string characterporturl) 
            : base(charactername, length, characterporturl) { }
    }
}

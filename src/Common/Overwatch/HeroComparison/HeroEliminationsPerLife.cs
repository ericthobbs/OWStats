using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Attributes;

namespace Common.Overwatch.HeroComparison
{
    [BlizzardGuid("overwatch.guid.0x08600000000003D2")]
    public class HeroEliminationsPerLife: HeroBaseCompare
    {
        public HeroEliminationsPerLife(string charactername, string length, string characterporturl) 
            : base(charactername, length, characterporturl) { }
    }
}

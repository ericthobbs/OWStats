using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Attributes;

namespace Common.Overwatch.HeroComparison
{
    [BlizzardGuid("overwatch.guid.0x0860000000000346")]
    public class HeroMultikillBest : HeroCompareBase
    {
        public HeroMultikillBest(string charactername, string length, string characterporturl)
            : base(charactername, length, characterporturl) { }
    }
}

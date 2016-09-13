using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Overwatch.HeroComparison
{
    public class HeroEliminationsPerLife: HeroBaseCompare
    {
        public HeroEliminationsPerLife(string charactername, string length, string characterporturl) 
            : base(charactername, length, characterporturl) { }
    }
}

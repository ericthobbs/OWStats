using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Overwatch.HeroComparison
{
    public class HeroCompareBase
    {
        public string Hero { get; private set; }
        public string Value { get; private set; }
        public Uri PortraitUri { get; private set; }

        public HeroCompareBase(string name, string value, string porturi)
        {
            Hero = name;
            Value = value;
            PortraitUri = new Uri(porturi);
        }
    }
}

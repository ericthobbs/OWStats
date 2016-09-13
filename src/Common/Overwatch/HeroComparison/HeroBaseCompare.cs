using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Overwatch.HeroComparison
{
    public class HeroBaseCompare
    {
        public string Hero { get; private set; }
        public string Value { get; private set; }
        public Uri PortraitUri { get; private set; }

        public HeroBaseCompare(string name, string value, string porturi)
        {
            Hero = name;
            Value = value;
            PortraitUri = new Uri(porturi);
        }
    }
}

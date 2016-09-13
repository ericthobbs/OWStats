using System;

namespace Common.Overwatch.HeroComparison
{
    public class HeroPlaytime : HeroBaseCompare
    {
        public HeroPlaytime(string charactername, string length, string characterporturl) 
            : base(charactername, length, characterporturl) { }

        private TimeSpan ParseHumanDate(string humanreadabledate)
        {
            int minutes = 0;

            if (humanreadabledate.Contains("hours"))
            {
                //remove hours string
                //convert to minutes 60*hours
            }
            else if (humanreadabledate.Contains("minutes"))
            {
                //remove minutes
                //pass back minutes
            }
            

            return new TimeSpan();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ProfileImporter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var importer = new Importer(SettingsManager.ApplicationSettings.ServerPath);

            var t1 = importer.ImportProfileAsync("RavenKnight#1137");
            var t2 = importer.ImportProfileAsync("Nugsly#1837");
            var t3 =  importer.ImportProfileAsync("LoadedDice#1534");

            Task.WaitAll(t1, t2, t3);

        }
    }
}

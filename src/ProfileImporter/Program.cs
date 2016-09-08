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
            importer.ImportProfileAsync("RavenKnight#1137");
        }
    }
}

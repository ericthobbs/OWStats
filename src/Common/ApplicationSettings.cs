﻿using System.Collections.Generic;

namespace Common
{
    public class ApplicationSettings
    {
        public string SaveLocation { get; set; }
        public string ServerPath { get; set; }
        public string UserAgent { get; set; }
        public List<string> Profiles { get; set; }
    }
}
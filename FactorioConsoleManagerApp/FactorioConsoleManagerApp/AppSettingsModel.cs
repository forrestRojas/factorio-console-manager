using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp
{
    /// <summary>
    /// Represents an AppSettings model.
    /// </summary>
    public class AppSettingsModel
    {
        public string ApplicationName { get; set; }
        public AppDataSection AppData { get; set; }
        public GameDataSection GameData { get; set; }

        public class AppDataSection
        {
            public string DataDir { get; set; }
            public string ChecksumsDir { get; set; }
            public string Lists { get; set; }
        }

        public class GameDataSection
        {
            public string ModsDir { get; set; }
            public string Lists { get; set; }
        }
    }
}

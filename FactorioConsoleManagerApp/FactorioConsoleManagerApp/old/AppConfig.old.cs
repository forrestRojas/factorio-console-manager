using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioConsoleManagerApp
{
    /// <summary>
    /// Represents an AppConfig class.
    /// </summary>
    public class AppSettingsModel
    {
        public string ApplicationName { get; set; }
        public AppDataConfig AppData { get; set; }
        public GameDataConfig GameData { get; set; }

        public class AppDataConfig
        {
            public PathStringsConfig PathStrings { get; set; }

            public class PathStringsConfig
            {
                public DirsConfig Dirs { get; set; }
                public FilesConfig Files { get; set; }

                public class DirsConfig
                {
                    public string Data { get; set; }

                    public string Checksums { get; set; }
                }

                public class FilesConfig
                {
                    public string Lists { get; set; }
                }
              }

            }

        public class GameDataConfig
        {
            public PathStringsConfig PathStrings { get; set; }

            public class PathStringsConfig
            {
                public DirsConfig Dirs { get; set; }
                public FilesConfig Files { get; set; }

                public class DirsConfig
                {
                    public string Mods { get; set; }
                }

                public class FilesConfig
                {
                    public string Lists { get; set; }
                }
            }

        }
    }
}

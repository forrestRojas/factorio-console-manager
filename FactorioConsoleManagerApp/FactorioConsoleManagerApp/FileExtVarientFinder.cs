using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactorioConsoleManagerApp
{
    public class FileExtVarientFinder
    {
        public bool HasJsonFileVariant(string filepath)
        {
            bool isValid = false;
            string path = filepath.Trim();
            const string json = ".json";

            if (!File.Exists(filepath))
            {
                return isValid;
            }

            FileInfo fileInfo = new FileInfo(path);
            if (isValid = json == fileInfo.Extension)
            {
                return isValid;
            }

            string pattern = Path.GetFileNameWithoutExtension(path) + json;
            DirectoryInfo directory = fileInfo.Directory;
            foreach (FileInfo file in directory.EnumerateFiles(pattern))
            {
                if (isValid = file != null)
                {
                    break;
                }
            }

            return isValid;
        }
    }
}

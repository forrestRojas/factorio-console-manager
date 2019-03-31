using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace FactorioConsoleManagerApp
{
    public class JsonValidator
    {
        public bool HasJsonFileVariant(string filepath)
        {
            bool isValid = false;
            string path = filepath.Trim();
            const string json = ".json";
            try
            {
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
            }
            catch (IOException)
            {
                // TODO Log validator
            }

            return isValid;
        }

        public bool IsVaildModList(string json)
        {
            bool isValid = false;
            return isValid;
        }
    }
}

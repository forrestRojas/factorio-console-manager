using FactorioConsoleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Converters;

namespace FactorioConsoleManagerApp.DAL
{
    public class ModListDAO : IModListDAO
    {
        private readonly string appdataFilePath;

        private readonly string gamedataFilePath;

        public ModListDAO(string appdataFilePath, string gamedataFilePath)
        {
            this.appdataFilePath = appdataFilePath;
            this.gamedataFilePath = gamedataFilePath;
        }

        public IDictionary<string, ModList> GetModLists(string filePath)
        {
            //IDictionary<list name, IDictionary<mod name, Mod>>
            SortedDictionary<string, ModList> modLists = new SortedDictionary<string, ModList>();
            DataSet jsonData = new DataSet();

            using (StreamReader sr = new StreamReader(appdataFilePath))
            {
                StringBuilder json = new StringBuilder();
                while (!sr.EndOfStream)
                {
                    json.Append(sr.ReadLine());
                }
                jsonData = JsonConvert.DeserializeObject<DataSet>(json.ToString());
            }

            foreach (DataTable table in jsonData.Tables)
            {                    
                ModList modList = ConvertTableToModList(table);
                modLists.Add(modList.Name, modList);
            }

            return modLists;
        }

        private ModList ConvertTableToModList(DataTable dataTable)
        {
            ModList modList = new ModList
            {
                Name = dataTable.TableName.ToLower(),
                ModListItems = new SortedDictionary<string, ModListItem>()
            };

            foreach (DataRow row in dataTable.Rows)
            {
                ModListItem modListItem = new ModListItem
                {
                    Name = Convert.ToString(row["name"]),
                    Enabled = Convert.ToBoolean(row["enabled"])
                };
                modList.ModListItems.Add(modListItem.Name, modListItem);
            }

            return modList;
        }

        public void SaveModLists()
        {
            throw new NotImplementedException();
        }
    }

}

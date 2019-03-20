using FactorioConsoleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Converters;

namespace FactorioConsoleManagerApp.DAL
{
    /// <summary>
    /// Represents a ModListJsonDAO that implments an IModListDAO.
    /// </summary>
    public class ModListJsonDAO : IModListDAO
    {
        private readonly string appdataFilePath;
        private readonly string gamedataFilePath;

        /// <summary>
        /// Creates a ModListDAO.
        /// </summary>
        /// <param name="appdataFilePath">The application's ModList file path</param>
        /// <param name="gamedataFilePath">The Game's ModList File Path</param>
        public ModListJsonDAO(string appdataFilePath, string gamedataFilePath)
        {
            this.appdataFilePath = appdataFilePath;
            this.gamedataFilePath = gamedataFilePath;
        }

        /// <summary>
        /// Gets all the ModLists saved in the application's data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, ModList> GetModListsFormApp()
        {
            return this.GetModLists(appdataFilePath);
        }

        /// <summary>
        /// Gets the Game's ModList from the mod-list json file.
        /// </summary>
        /// <returns>The game's ModList</returns>
        public ModList GetModListFormGame()
        {
            IDictionary<string, ModList> modLists = this.GetModLists(gamedataFilePath);
            return modLists["mods"];

        }

        /// <summary>
        /// Saves the ModLists to the application list file
        /// </summary>
        /// <param name="modLists">Dictionary of ModLists to save</param>
        public void SaveModLists(IDictionary<string, ModList> modLists)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Write/Overwrites the ModList to the game mod-list file.
        /// </summary>
        /// <param name="modList">The list to use</param>
        public void WriteModListToGameModsFolder(ModList modList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an IDictionary of Modlist from a specifed json <see cref="DataSet"/> file accessed by the List Name.
        /// </summary>
        /// <param name="filePath">The File path to the json file</param>
        /// <returns>IDctionaray of ModLists</returns>
        private IDictionary<string, ModList> GetModLists(string filePath)
        {
            Action<Exception> ErrorHandler = (ex) => {
                // TODO LOG exception GetModLists method then pass up the chain
            };

            //IDictionary<list name, IDictionary<mod name, Mod>>
            SortedDictionary<string, ModList> modLists = new SortedDictionary<string, ModList>();
            try
            {
                DataSet jsonData = new DataSet();
                using (StreamReader sr = new StreamReader(appdataFilePath))
                {
                    StringBuilder json = new StringBuilder();
                    while (!sr.EndOfStream)
                    {
                        json.Append(sr.ReadLine());
                    }
                    // TODO Vaildate json Scheme to work with dataSets THROW error if vaildation fails
                    //json.VaidataScheme();
                    jsonData = JsonConvert.DeserializeObject<DataSet>(json.ToString());
                }

                foreach (DataTable table in jsonData.Tables)
                {                    
                    ModList modList = ConvertTableToModList(table);
                    modLists.Add(modList.Name, modList);
                }
            }
            catch (FileNotFoundException ex) { ErrorHandler(ex); throw; }
            catch (FileLoadException ex) { ErrorHandler(ex); throw; }
            catch (IOException ex) { ErrorHandler(ex); throw; }
            catch (JsonSerializationException ex) { ErrorHandler(ex); throw; }
            catch (JsonException ex) { ErrorHandler(ex); throw; }
            return modLists;
        }

        /// <summary>
        /// Converts the Table data to a ModList.
        /// </summary>
        /// <param name="dataTable">the table of mods assiocated with the list</param>
        /// <returns>A ModList</returns>
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
    }

}

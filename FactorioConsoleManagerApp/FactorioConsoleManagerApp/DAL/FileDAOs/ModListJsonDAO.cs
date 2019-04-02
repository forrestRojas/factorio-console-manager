using FactorioConsoleManagerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using FactorioConsoleManagerApp.JsonSchemas;
using System.Diagnostics;

namespace FactorioConsoleManagerApp.DAL
{
    /// <summary>
    /// Represents a ModListJsonDAO that implments an IModListDAO.
    /// </summary>
    public class ModListJsonDAO : IModListDAO
    {
        private readonly string appJson;
        private readonly string gameJson;
        private readonly IJSchemaHandler schemaHandler;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// Creates a ModListJsonDAO.
        /// </summary>
        /// <param name="appdataModListsPath">The application's ModList file path</param>
        /// <param name="gamedataModListPath">The Game's ModList File Path</param>
        public ModListJsonDAO(string appdataModListsPath, string gamedataModListPath)
        {
            this.appJson = appdataModListsPath;
            this.gameJson = gamedataModListPath;
            // TODO Complete DI for Json Schema Handler
            this.schemaHandler = new JSchemaHandler();
        }

        /// <summary>
        /// Gets all the ModLists saved in the application's data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, ModList> GetAppLists()
        {
            return this.GetModListsFromJson(this.appJson);
        }

        /// <summary>
        /// Gets the Game's ModList from the mod-list json file.
        /// </summary>
        /// <returns>The game's ModList</returns>
        public ModList GetGameList()
        {
            IDictionary<string, ModList> modLists = this.GetModListsFromJson(this.gameJson);
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
        public void WriteListToGame(ModList modList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an IDictionary of Modlist from a specifed json <see cref="DataSet"/> file accessed by the List Name.
        /// </summary>
        /// <param name="filePath">The File path to the json file</param>
        /// <returns>IDctionaray of ModLists</returns>
        private IDictionary<string, ModList> GetModListsFromJson(string filePath)
        {
            Action<Exception> ErrorHandler = (ex) => {
                // TODO LOG exception GetModLists method then pass up the chain
            };

            Dictionary<string, ModList> modLists = new Dictionary<string, ModList>();
            try
            {
                // TODO Optimize json deserilzers | line 99 and line 105
                DataSet jsonData;
                using (StreamReader sr = new StreamReader(filePath))
                using (JsonReader reader = new JsonTextReader(sr))
                using (JSchemaValidatingReader validatingReader = new JSchemaValidatingReader(reader))
                {
                    validatingReader.Schema = schemaHandler.GetModListsSchema();

                    IList<string> messages = new List<string>();
                    validatingReader.ValidationEventHandler += (o, a) => messages.Add(a.Message);

                    JsonSerializer serializer = new JsonSerializer();
                    jsonData = serializer.Deserialize<DataSet>(validatingReader);
                }
                modLists = ConvertTablesToModListsDictionary(jsonData.Tables);
            }
            catch (FileNotFoundException ex) { ErrorHandler(ex); throw; }
            catch (FileLoadException ex) { ErrorHandler(ex); throw; }
            catch (DirectoryNotFoundException ex) { ErrorHandler(ex);  throw; }
            catch (JsonSerializationException ex) { ErrorHandler(ex); throw; }
            catch (JsonException ex) { ErrorHandler(ex); throw; }

            return modLists;
        }

        /// <summary>
        /// Converts the table collection to a dictionary
        /// </summary>
        /// <param name="tables">a collection of dataTabls</param>
        /// <returns></returns>
        private Dictionary<string, ModList> ConvertTablesToModListsDictionary(DataTableCollection tables)
        {
            Dictionary<string, ModList> output = new Dictionary<string, ModList>();
            foreach (DataTable table in tables)
            {
                string name = table.TableName.ToLower();
                ModList list = ConvertTableToModList(table);
                output.Add(name, list);
            }

            return output;
        }

        /// <summary>
        /// Converts the Table data to a ModList.
        /// </summary>
        /// <param name="dataTable">the table of mods assiocated with the list</param>
        /// <returns>A ModList</returns>
        private ModList ConvertTableToModList(DataTable table)
        {
            ModList modList = new ModList
            {
                Name = table.TableName.ToLower(),
                ModListItems = CovertDataRowsToModListItems(table.Rows)
            };

            return modList;
        }


        /// <summary>
        /// Converts DataRows to modlistItems.
        /// </summary>
        /// <param name="rows">Acollection of data rows.</param>
        /// <returns></returns>
        private IDictionary<string, ModListItem> CovertDataRowsToModListItems(DataRowCollection rows)
        {
            Dictionary<string, ModListItem> modListItems = new Dictionary<string, ModListItem>();
            foreach (DataRow row in rows)
            {
                ModListItem modListItem = new ModListItem
                {
                    Name = Convert.ToString(row["name"]),
                    Enabled = Convert.ToBoolean(row["enabled"])
                };
                modListItems.Add(modListItem.Name, modListItem);
            }

            return modListItems;
        }
    }

}

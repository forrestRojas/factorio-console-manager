using Newtonsoft.Json.Schema;

namespace FactorioConsoleManagerApp.JsonSchemas
{
    /// <summary>
    /// Represents a Json Schema handler.
    /// </summary>
    public interface IJSchemaHandler
    {
        /// <summary>
        /// Gets the mod lists schema.
        /// </summary>
        /// <returns></returns>
        JSchema GetModListsSchema();
    }
}
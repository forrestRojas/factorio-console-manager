using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace FactorioConsoleManagerApp.JsonSchemas
{
    public class JSchemaHandler : IJSchemaHandler
    {
        private readonly string modListsSchemaPath;

        public JSchemaHandler()
        {
            // TODO Complete The DI for the SchemaHandler
            this.modListsSchemaPath = "JsonSchemas/modlist-schema.json";
        }

        public JSchema GetModListsSchema()
        {
            JSchema schema;
            using (StreamReader sr = new StreamReader(this.modListsSchemaPath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                schema = JSchema.Load(reader);
            }

            return schema;
        }
    }
}

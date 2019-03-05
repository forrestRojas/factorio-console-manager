using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using Newtonsoft.Json.Converters;

namespace FactorioConsoleManagerApp
{
    public class Startup
    {

        public string AppdataDir { get; }

        public Startup()
        {
            //Newtonsoft.Json.Converters.DataSetConverter

            

            //this.AppdataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //IConfigurationBuilder builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddEnvironmentVariables();

            //IConfigurationRoot configuration = builder.Build();

            //this.Configuration = configuration;
        }


    }
}

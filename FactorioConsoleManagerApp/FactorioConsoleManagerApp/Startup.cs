using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.FileProviders;

namespace FactorioConsoleManagerApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public string AppdataDir { get; }

        public Startup()
        {
            this.AppdataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            this.Configuration = configuration;
        }


    }
}

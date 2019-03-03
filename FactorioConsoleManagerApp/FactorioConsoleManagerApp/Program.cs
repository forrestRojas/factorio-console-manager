using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using FactorioConsoleManagerApp.CLI;

namespace FactorioConsoleManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup startup = new Startup();
            startup.
            string gamedata = startup.Configuration.GetSection("Paths")["gamedata"];
            Console.WriteLine(gamedata);
        }
    }
}

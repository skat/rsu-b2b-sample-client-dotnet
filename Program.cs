using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace UFSTWSSecuritySample
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            Settings settings = configuration.GetSection("Settings").Get<Settings>();
            Endpoints endpoints = configuration.GetSection("Endpoints").Get<Endpoints>();

            Console.WriteLine($"Path to PCKS#12 file = {settings.PathPKCS12}");
            Console.WriteLine($"Path to PEM file = {settings.PathPEM}");
            Console.WriteLine($"VirksomhedKalenderHent = {endpoints.VirksomhedKalenderHent}");

            if (!File.Exists(settings.PathPKCS12))
            {
                Console.WriteLine("Cannot find " + settings.PathPKCS12);
                Console.WriteLine("Aborting run...");
                return;
            }

            if (!File.Exists(settings.PathPEM))
            {
                Console.WriteLine("Cannot find " + settings.PathPEM);
                Console.WriteLine("Aborting run...");
                return;
            }

            if (args.Length == 0)
            {
                Console.WriteLine("Invalid args");
                return;
            }

            var command = args[0];

            IApiClient client = new ApiClient(settings);
            switch (command)
            {
                case "VirksomhedKalenderHent":
                    await client.CallService(new VirksomhedKalenderHentWriter("12345678", "2020-01-01", "2020-01-01"), endpoints.VirksomhedKalenderHent);
                    Console.WriteLine("Finished");
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    Console.WriteLine("dotnet run [VirksomhedKalenderHent]");
                    break;
            }
        }
    }
}

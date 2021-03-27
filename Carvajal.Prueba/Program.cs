using Carvajal.Prueba.Extension;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Carvajal.Prueba
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
            .Build()
            .MigrateDatabase()
            .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://0.0.0.0:4000");
                    webBuilder.UseStartup<Startup>();
                });
    }
}

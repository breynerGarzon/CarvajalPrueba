using Carvajal.Prueba.Business.Interface;
using Carvajal.Prueba.Business.Services;
using Carvajal.Prueba.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carvajal.Prueba.Extension
{
    public static class InicializeContext
    {
        public static void ConfigureBusinessContext(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection("AppSettings");
            // var Configuracion = appSettings.Get<Configuracion>();
            // services.Configure<Configuracion>(appSettings);
            var sqlConnectionString = configuration.GetConnectionString("SQLServer");
            services.AddDbContext<CarvajalContext>(options => options.UseSqlServer(sqlConnectionString,
                                                                                    option => option.MigrationsAssembly("Carvajal.Prueba.MigrationSQLSERVER")));
        }
    }
}
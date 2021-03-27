using Carvajal.Prueba.Business.Interface;
using Carvajal.Prueba.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Carvajal.Prueba.Extension
{
    public static class InicializeBusinessServices
    {
        public static void ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<ILoginBusinessServices, LogInBusinessServices>();
            services.AddTransient<IDocumentTypeBusinessServices, DocumentTypeBusinessServices>();
            services.AddTransient<IUserBusinessServices, UserBusinessServices>();
        }
    }
}
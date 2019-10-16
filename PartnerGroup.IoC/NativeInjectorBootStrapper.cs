using Microsoft.Extensions.DependencyInjection;
using PartnerGroup.Aplicacao.Interfaces;
using PartnerGroup.Aplicacao.Servicos;
using PartnerGroup.Persistencia.Repositorios;

namespace PartnerGroup.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMarcaServico, MarcaServico>();
            services.AddScoped<IPatrimonioServico, PatrimonioServico>();

            services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();
            services.AddScoped<IPatrimonioRepositorio, PatrimonioRepositorio>();
        }
    }
}

using api_bot.Services;

namespace api_bot.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            // Centralize todos os seus registros aqui
            services.AddScoped<FaturaServiceImp, FaturaService>();
            services.AddScoped<ClientServiceImp, ClientService>();
            services.AddScoped<CcrServiceImp, CcrService>();
            services.AddScoped<ContratoServiceImp, ContratoService>();

            return services;
        }
    }
}
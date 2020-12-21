using AnaliseDados.Infra.Repositories;
using AnaliseDados.Domain.Interfaces;
using AnaliseDados.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AnaliseDados.Factories
{
    public class ServiceProviderFactory
    {
        private readonly IConfiguration _configuration;

        public ServiceProviderFactory()
        {
            _configuration = new ConfigurationFactory().Generate();
        }

        public IServiceProvider Generate()
        {
            var services = new ServiceCollection();

            services.AddSingleton(_configuration);

            services.AddScoped<IDadosRepository, DadosRepository>();
            services.AddScoped<IGerenciadorService, GerenciadorService>();
            services.AddScoped<ILeituraDadosService, LeituraDadosService>();

            return services.BuildServiceProvider();
        }
    }
}

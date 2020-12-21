using AnaliseDados.CrossCutting.Enums;
using AnaliseDados.Domain.Interfaces;
using AnaliseDados.Domain.Services;
using AnaliseDados.Factories;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnaliseDados
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceProviderFactory().Generate();
            var gerenciador = serviceProvider.GetService<IGerenciadorService>();

            var ordemExecucao = new Dictionary<ETipoDado, IAnaliseService>
            {
                {ETipoDado.Cliente, new ClientesAnaliseService()},
                {ETipoDado.Vendedor, new VendedoresAnaliseService()},
                {ETipoDado.Venda, new VendasAnaliseService()},
            };

            await gerenciador.ExecutarProcesso(ordemExecucao);
        }
    }
}

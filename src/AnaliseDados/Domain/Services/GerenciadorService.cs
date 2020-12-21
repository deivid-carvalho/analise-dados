using AnaliseDados.CrossCutting.Enums;
using AnaliseDados.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnaliseDados.Domain.Services
{
    public class GerenciadorService : IGerenciadorService
    {
        private readonly IDadosRepository _dadosRepository;

        public GerenciadorService(IDadosRepository dadosRepository)
        {
            _dadosRepository = dadosRepository;
        }

        public async Task ExecutarProcesso(IDictionary<ETipoDado, IAnaliseService> execucoes)
        {
            var dadosGerais = await _dadosRepository.ListarDados();

            foreach (var execucao in execucoes)
            {
                var dados = dadosGerais.Where(d => d.Tipo == execucao.Key).ToList();

                var relatorioLinha = await execucao.Value.GerarAnalise(dados);

                await _dadosRepository.AdcionarLinhaRelatorio(relatorioLinha);
            }
        }
    }
}

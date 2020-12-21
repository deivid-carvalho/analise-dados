using AnaliseDados.CrossCutting.Enums;
using AnaliseDados.Domain.Interfaces;
using AnaliseDados.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace AnaliseDados.Infra.Repositories
{
    public class DadosRepository : IDadosRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILeituraDadosService _leituraDadosService;

        public DadosRepository(IConfiguration configuration, ILeituraDadosService leituraDadosService)
        {
            _configuration = configuration;
            _leituraDadosService = leituraDadosService;
        }

        public async Task AdcionarLinhaRelatorio(string linha)
        {
            var caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _configuration["CaminhoSaida"], "relatorio.done.dat");

            using (StreamWriter sw = new StreamWriter(caminho,true))
            {
                sw.WriteLine(linha);
            }
        }

        public async Task<ICollection<Dado>> ListarDados()
        {
            var dados = new List<Dado>();

            var caminho =  Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _configuration["CaminhoEntrada"]);
            string[] arquivos = Directory.GetFiles(caminho, "*.dat");

            foreach (var arquivo in arquivos)
            {
                dados.AddRange(await _leituraDadosService.BuscarDadosDoArquivo(arquivo));
            }

            return dados;
        }
    }
}

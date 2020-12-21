using AnaliseDados.CrossCutting.Enums;
using AnaliseDados.Domain.Interfaces;
using AnaliseDados.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AnaliseDados.Domain.Services
{
    public class LeituraDadosService : ILeituraDadosService
    {
        public async Task<ICollection<Dado>> BuscarDadosDoArquivo(string arquivo)
        {
            var dados = new List<Dado>();

            using (StreamReader sr = new StreamReader(arquivo))
            {
                while (sr.Peek() >= 0)
                {
                    var linhaDados = sr.ReadLine().Split("ç");
                    var tipoDado = (ETipoDado)int.Parse(linhaDados[0]);

                    switch (tipoDado)
                    {
                        case ETipoDado.Vendedor:
                            dados.Add(Vendedor.Map(linhaDados));
                            break;
                        case ETipoDado.Cliente:
                            dados.Add(Cliente.Map(linhaDados));
                            break;
                        case ETipoDado.Venda:
                            dados.Add(Venda.Map(linhaDados));
                            break;
                        default:
                            throw new Exception("O programa não suporta os tipos de dados informados");
                    }
                }
            }

            return dados;
        }
    }
}

using AnaliseDados.CrossCutting.Enums;
using AnaliseDados.Domain.Interfaces;
using AnaliseDados.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnaliseDados.CrossCutting.Extensions;

namespace AnaliseDados.Domain.Services
{
    public class VendasAnaliseService : IAnaliseService
    {
        private ICollection<Venda> Vendas;

        public async Task<string> GerarAnalise(ICollection<Dado> dados)
        {
            if (dados.Any(d => d.Tipo != ETipoDado.Venda))
            {
                throw new ArgumentException("O serviço de vendas não suporta o tipo de dado informado");
            }

            if (dados.IsNullOrEmpty())
            {
                return "Nenhum dado de vendas na carga";
            }

            Vendas = dados.Cast<Venda>().ToList();

            var linhas = new StringBuilder()
                .AppendLine(GerarAnaliseVendaMaisCara())
                .AppendLine(GerarAnalisePiorVendendor());

            return linhas.ToString();
        }

        private string GerarAnaliseVendaMaisCara()
        {
            var vendaMaisCara = Vendas.OrderByDescending(v => v.ValorTotal).FirstOrDefault();

            return $"A venda mais cara foi a {vendaMaisCara.Id} no valor de {vendaMaisCara.ValorTotal:C}";
        }

        private string GerarAnalisePiorVendendor()
        {
            var piorVendedor = Vendas
                .GroupBy(v => v.VendedorNome)
                .Select(v => new { Vendedor = v.Key, ValorDeVendas = v.Sum(t => t.ValorTotal) })
                .OrderBy(v => v.ValorDeVendas)
                .FirstOrDefault();

            return $"O pior vendedor foi o {piorVendedor.Vendedor} com o valot total de {piorVendedor.ValorDeVendas:C}";
        }
    }
}

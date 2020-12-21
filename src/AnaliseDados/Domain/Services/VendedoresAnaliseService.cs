using AnaliseDados.CrossCutting.Enums;
using AnaliseDados.CrossCutting.Extensions;
using AnaliseDados.Domain.Interfaces;
using AnaliseDados.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnaliseDados.Domain.Services
{
    public class VendedoresAnaliseService : IAnaliseService
    {
        public async Task<string> GerarAnalise(ICollection<Dado> dados)
        {
            if (dados.Any(d => d.Tipo != ETipoDado.Vendedor))
            {
                throw new ArgumentException("O serviço de vendedores não suporta o tipo de dado informado");
            }

            if (dados.IsNullOrEmpty())
            {
                return "Nenhum vendedores de vendas na carga";
            }

            return $"Quantidade de vendedores: {dados.Count()}";
        }
    }
}

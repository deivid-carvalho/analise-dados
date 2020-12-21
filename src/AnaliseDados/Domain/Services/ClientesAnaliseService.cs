using AnaliseDados.CrossCutting.Enums;
using AnaliseDados.CrossCutting.Extensions;
using AnaliseDados.Domain.Interfaces;
using AnaliseDados.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseDados.Domain.Services
{
    public class ClientesAnaliseService : IAnaliseService
    {
        public async Task<string> GerarAnalise(ICollection<Dado> dados)
        {

            if(dados.Any(d => d.Tipo != ETipoDado.Cliente))
            {
                throw new ArgumentException("O serviço de cliente não suporta o tipo de dado informado");
            }

            if (dados.IsNullOrEmpty())
            {
                return "Nenhum dado de clientes na carga";
            }


            return $"Quantidade de clientes: {dados.Count()}";
        }
    }
}

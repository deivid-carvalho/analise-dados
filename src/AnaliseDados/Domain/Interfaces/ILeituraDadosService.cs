using AnaliseDados.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnaliseDados.Domain.Interfaces
{
    public interface ILeituraDadosService
    {
        Task<ICollection<Dado>> BuscarDadosDoArquivo(string arquivo);
    }
}

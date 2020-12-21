using AnaliseDados.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnaliseDados.Domain.Interfaces
{
    public interface IDadosRepository
    {
        Task<ICollection<Dado>> ListarDados();
        Task AdcionarLinhaRelatorio(string linha);
    }
}

using AnaliseDados.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnaliseDados.Domain.Interfaces
{
    public interface IAnaliseService
    {
        Task<string> GerarAnalise(ICollection<Dado> dados);
    }
}

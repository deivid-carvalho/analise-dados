using AnaliseDados.CrossCutting.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnaliseDados.Domain.Interfaces
{
    public interface IGerenciadorService
    {
        Task ExecutarProcesso(IDictionary<ETipoDado, IAnaliseService> ordemExecucao);
    }
}

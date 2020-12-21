using AnaliseDados.CrossCutting.Enums;

namespace AnaliseDados.Domain.Models
{
    public abstract class Dado
    {
        public ETipoDado Tipo { get; protected set; }

        protected Dado(ETipoDado tipo)
        {
            Tipo = tipo;
        }
    }
}

using AnaliseDados.CrossCutting.Enums;

namespace AnaliseDados.Domain.Models
{
    public class Cliente : Dado
    {
        public string Cnpj { get; private set; }
        public string RazaoSocial { get; private set; }
        public string TipoNegocio { get; private set; }

        public Cliente(string cnpj, string razaoSocial, string tipoNegocio) : base(ETipoDado.Cliente)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            TipoNegocio = tipoNegocio;
        }

        public static Cliente Map(string[] dados)
        {
            return new Cliente
            (
                dados[1],
                dados[2],
                dados[3]
            );
        }
    }
}

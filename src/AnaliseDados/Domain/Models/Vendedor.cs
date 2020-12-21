using AnaliseDados.CrossCutting.Enums;

namespace AnaliseDados.Domain.Models
{
    public class Vendedor : Dado
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }

        public Vendedor(string cpf, string nome, decimal salario) : base(ETipoDado.Vendedor)
        {
            Cpf = cpf;
            Nome = nome;
            Salario = salario;
        }

        public static Vendedor Map(string[] dados)
        {
            return new Vendedor
            (
                dados[1],
                dados[2],
                decimal.Parse(dados[3])
            );
        }
    }
}

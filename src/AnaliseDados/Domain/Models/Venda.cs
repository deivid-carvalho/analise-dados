using AnaliseDados.CrossCutting.Enums;
using System.Collections.Generic;
using System.Linq;

namespace AnaliseDados.Domain.Models
{
    public class Venda : Dado
    {
        public string Id { get; set; }
        public string VendedorNome { get; set; }
        public ICollection<Item> Itens { get; set; }

        public decimal ValorTotal => Itens.Sum(i => i.ValorTotal);

        public Venda(string id, string vendedorNome, ICollection<Item> itens) : base(ETipoDado.Venda)
        {
            Id = id;
            VendedorNome = vendedorNome;
            Itens = itens;
        }

        public static Venda Map(string[] dados)
        {
            var itens = dados[2]
                .Replace("[", "")
                .Replace("]", "")
                .Split(",");

            return new Venda
            (
                dados[1],
                dados[3],
                itens.Select(i => Item.Map(i.Split("-"))).ToList()
            );
        }
    }
}

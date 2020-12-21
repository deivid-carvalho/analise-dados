namespace AnaliseDados.Domain.Models
{
    public class Item
    {
        public long Id { get; set; }
        public long Quantidade { get; set; }
        public decimal Preco { get; set; }
        
        public decimal ValorTotal => Quantidade * Preco;

        public Item(long id, long quantidade, decimal preco)
        {
            Id = id;
            Quantidade = quantidade;
            Preco = preco;
        }

        public static Item Map(string[] dados)
        {
            return new Item
            (
                long.Parse(dados[0]),
                long.Parse(dados[1]),
                decimal.Parse(dados[2])
            );
        }
    }
}

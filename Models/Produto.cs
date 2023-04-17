namespace Models
{
    public class Produto
    {
        public int Id {get; set;}
        public string Nome {get;set;}
        public double Preco {get; set;}

        public Produto(string Nome, double Preco)
        {
            Nome = nome;
            Preco = Preco;
        }
    }
}
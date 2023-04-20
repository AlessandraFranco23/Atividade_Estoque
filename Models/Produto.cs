namespace Models
{
    public class Produto
    {
        public int Id {get; set;}
        public string Nome {get;set;}
        public double Preco {get; set;}

        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = Preco;
        }
        
        public string[] toRow() {
            string[] row = { Id.ToString(), Nome, Preco.ToString()};
            return row;
        }
    }
}
namespace Models
{
    public class SaldoFormView
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public SaldoFormView(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
    
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("preco")]
        public double Preco { get; set; }

        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public Produto(int id, string nome, double preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }
        public string[] toRow()
        {
            string[] row = { Id.ToString(), Nome, Preco.ToString() };
            return row;
        }
    }
}
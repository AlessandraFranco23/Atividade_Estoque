using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Almoxarifado")]
    public class Almoxarifado
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        public Almoxarifado(string nome)
        {
            Nome = nome;
        }

        public Almoxarifado(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public string[] toRow()
        {
            string[] row = { Id.ToString(), Nome };
            return row;
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Saldo")]
    public class Saldo
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        public Produto Produto { get; set; }

        public Almoxarifado Almoxarifado { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }



        public Saldo(Produto produto, Almoxarifado almoxarifado, int quantidade)
        {
            Produto = produto;
            Almoxarifado = almoxarifado;
            Quantidade = quantidade;
        }

        public Saldo(int id, Produto produto, Almoxarifado almoxarifado, int quantidade)
        {
            Id = id;
            Produto = produto;
            Almoxarifado = almoxarifado;
            Quantidade = quantidade;
        }

        public Saldo()
        {
        }

        public string[] toRow()
        {
            string[] row = { Id.ToString(), Produto.Nome.ToString(), Almoxarifado.Nome.ToString(), Quantidade.ToString() };
            return row;
        }
    }
}
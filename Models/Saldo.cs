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
        
        public Produto Produto {get; set;}

        [Column("produto_id")]
        public int ProdutoId { get; set; }

        public Almoxarifado Almoxarifado {get;set;}

        [Column("almoxarifado_id")]
        public int AlmoxarifadoId { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        public Saldo(Produto produto, Almoxarifado almoxarifado, int quantidade)
        {
            Produto = produto;
            ProdutoId = produto.Id;
            Almoxarifado = almoxarifado;
            AlmoxarifadoId = almoxarifado.Id;
            Quantidade = quantidade;
        }

        public Saldo(int id, Produto produto, Almoxarifado almoxarifado, int quantidade )
        {
            Id = id;
           Produto = produto;
            ProdutoId = produto.Id;
            Almoxarifado = almoxarifado;
            AlmoxarifadoId = almoxarifado.Id;
            Quantidade = quantidade;
        }
        public string[] toRow()
        {
            string[] row = { Id.ToString(), Produto.Nome.ToString(), Almoxarifado.Nome.ToString(), Quantidade.ToString() };
            return row;
        }
    }
}
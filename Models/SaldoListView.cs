namespace Models
{
    public class SaldoListView
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string NomeAlmoxarifado { get; set; }
        public int Quantidade { get; set; }
        public double Total { get; set; }

        private SaldoListView(int id, string nomeProduto, string nomeAlmoxarifado, int quantidade, double total)
        {
            Id = id;
            NomeProduto = nomeProduto;
            NomeAlmoxarifado = nomeAlmoxarifado;
            Quantidade = quantidade;
            Total = total;
        }

        public static SaldoListView from(Saldo saldo) {
            double total = saldo.Produto.Preco * saldo.Quantidade; 
            return new Models.SaldoListView(saldo.Id, saldo.Produto.Nome, saldo.Almoxarifado.Nome, saldo.Quantidade, total);
        }

        public string[] toRow()
        {
            string[] row = { Id.ToString(), NomeProduto, NomeAlmoxarifado, Quantidade.ToString(), String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", Total) };
            return row;
        }
    }

}
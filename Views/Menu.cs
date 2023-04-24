
namespace Views
{
    public class Menu : Form
    {

        Button produto = new Button();
        Button sair = new Button();
        Button almoxarifado = new Button();
        Button saldo = new Button();

        // Models.Context context = new Models.Context();


        public void FormLayout()
        {
            this.Name = "MENU";
            this.Text = "Menu Estoque";
            this.Size = new Size(450, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            produto.Text = "Produto";
            produto.Name = "Produto";
            produto.Location = new Point(75, 100);
            produto.Height = 40;
            produto.Width = 300;
            produto.Click += new EventHandler(Produto_Click);

            almoxarifado.Text = "Almoxarifado";
            almoxarifado.Name = "Almoxarifado";
            almoxarifado.Location = new Point(75, 150);
            almoxarifado.Height = 40;
            almoxarifado.Width = 300;
            almoxarifado.Click += new EventHandler(Almoxarifado_Click);

            saldo.Text = "Saldo";
            saldo.Name = "Saldo";
            saldo.Location = new Point(75, 200);
            saldo.Height = 40;
            saldo.Width = 300;
            saldo.Click += new EventHandler(Saldo_Click);

            sair.Text = "Sair";
            sair.Name = "Sair";
            sair.Location = new Point(75, 250);
            sair.Height = 40;
            sair.Width = 300;
            sair.Click += new EventHandler(Sair_Click);

            Controls.Add(produto);
            Controls.Add(almoxarifado);
            Controls.Add(saldo);
            Controls.Add(sair);

        }
        public void Produto_Click(object sender, EventArgs e)
        {
            using var context = new Models.Context();

            Lista f3 = new Lista(context);
            f3.FormLayout();
            f3.Show();
        }
        public void Almoxarifado_Click(object sender, EventArgs e)
        {
            using var context = new Models.Context();

            ListaAlmoxarifado f6 = new ListaAlmoxarifado(context);
            f6.FormLayout();
            f6.Show();
        }
        public void Saldo_Click(object sender, EventArgs e)
        {
            using var context = new Models.Context();

            ListaSaldo f7 = new ListaSaldo(context);
            f7.FormLayout();
            f7.Show();
        }
        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

namespace Views
{
    public class Menu : Form
    {

        Button produto = new Button();
        Button sair = new Button();
        Models.Context context = new Models.Context();


        public void FormLayout()
        {
            this.Name = "MENU";
            this.Text = "Menu Estoque";
            this.Size = new Size(450, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            produto.Text = "Produto";
            produto.Name = "Produto";
            produto.Location = new Point(75, 120);
            produto.Height = 40;
            produto.Width = 300;
            produto.Click += new EventHandler(Produto_Click);

            sair.Text = "Sair";
            sair.Name = "Sair";
            sair.Location = new Point(75, 240);
            sair.Height = 40;
            sair.Width = 300;
            sair.Click += new EventHandler(Sair_Click);

            Controls.Add(produto);
            Controls.Add(sair);

        }
        public void Produto_Click(object sender, EventArgs e)
        {
            Lista f3 = new Lista(context);
            f3.FormLayout();
            f3.Show();
        }
        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
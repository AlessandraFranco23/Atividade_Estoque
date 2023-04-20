namespace Views
{
    class Produto : Form
    {
        Button cancelar = new Button();
        Button confirmar = new Button();
        Label nomeProdutoLabel = new Label();
        TextBox nomeProduto = new TextBox();
        Label precoProdutoLabel = new Label();
        TextBox precoProduto = new TextBox();
        Controllers.Produto Controller;
        private readonly Lista Lista;
        private Models.Produto produto;
        public Produto(Controllers.Produto controller, Lista lista)
        {
            Controller = controller;
            Lista = lista;
        }

        public void FormLayout()
        {

            this.Name = "PRODUTO";
            this.Text = "Cadastro do produto";
            this.Size = new Size(450, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            nomeProdutoLabel.Text = "Nome:";
            nomeProdutoLabel.Location = new Point(10, 10);

            nomeProduto.Location = new Point(110, 10);

            precoProdutoLabel.Text = "Preço:";
            precoProdutoLabel.Location = new Point(10, 50);

            precoProduto.Location = new Point(110, 50);

            confirmar.Text = "Confirmar";
            confirmar.Name = "Confirmar";
            confirmar.Location = new Point(225, 325);
            confirmar.Height = 20;
            confirmar.Width = 100;
            confirmar.Click += new EventHandler(Confirmar_Click);

            cancelar.Text = "Cancelar";
            cancelar.Name = "Cancelar";
            cancelar.Location = new Point(325, 325);
            cancelar.Height = 20;
            cancelar.Width = 100;
            cancelar.Click += new EventHandler(Cancelar_Click);


            Controls.Add(confirmar);
            Controls.Add(cancelar);
            Controls.Add(nomeProdutoLabel);
            Controls.Add(nomeProduto);
            Controls.Add(precoProdutoLabel);
            Controls.Add(precoProduto);
        }

        public void Alterar(int id)
        {
            produto = Controller.GetById(id);

            if (produto != null)
            {
                nomeProduto.Text = produto.Nome;
                precoProduto.Text = produto.Preco.ToString();
            }
        }

        public void Confirmar_Click(object sender, EventArgs e)
        {
            if (produto == null)
            {
                Controller.Criar(nomeProduto.Text, double.Parse(precoProduto.Text));
            }
            else
            {
                Controller.Alterar(produto.Id, nomeProduto.Text, double.Parse(precoProduto.Text));
            }

            Lista.Refresh();
            this.Close();
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
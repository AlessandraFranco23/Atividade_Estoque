namespace Views
{
    class Saldo: Form
    {
        Button cancelar = new Button();
        Button confirmar = new Button();
        Label idProdutoLabel = new Label();
        TextBox idProduto = new TextBox();
        Label idAlmoxarifadoLabel = new Label();
        TextBox idAlmoxarifado = new TextBox();
        Label quantidadeLabel = new Label();
        TextBox quantidade = new TextBox();
        public Controllers.Saldo Controller { get; }
        public ListaSaldo ListaSaldo { get; }
        private Models.Saldo saldo;

        public Saldo(Controllers.Saldo controller, ListaSaldo listaSaldo)
        {
            Controller = controller;
            ListaSaldo = listaSaldo;
        }


        public void FormLayout()
        {
            this.Name = "SALDO";
            this.Text = "Cadastro de saldo";
            this.Size = new Size(450, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            idProdutoLabel.Text = "Id do Produto:";
            idProdutoLabel.Location = new Point(10, 10);

            idProduto.Location = new Point(110, 10);

            idAlmoxarifadoLabel.Text = "Id do Almoxarifado:";
            idAlmoxarifadoLabel.Location = new Point(10, 50);
            idAlmoxarifadoLabel.Size = new Size (100,50);

            idAlmoxarifado.Location = new Point(110, 50);

            quantidadeLabel.Text = "Quantidade:";
            quantidadeLabel.Location = new Point(10, 100);

            quantidade.Location = new Point(110, 100);

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
            Controls.Add(idProdutoLabel);
            Controls.Add(idProduto);
            Controls.Add(idAlmoxarifadoLabel);
            Controls.Add(idAlmoxarifado);
            Controls.Add(quantidadeLabel);
            Controls.Add(quantidade);
        }

        public void Alterar(int id)
        {
            saldo = Controller.GetById(id);

            if (saldo != null)
            {
                idProduto.Text = saldo.Produto.Id.ToString();
                idAlmoxarifado.Text = saldo.Almoxarifado.Id.ToString();
                quantidade.Text = saldo.Quantidade.ToString();
            }
        }
        public void Confirmar_Click(object sender, EventArgs e)
        {
            if (saldo == null)
            {
                try {
                    Controller.Criar(Int32.Parse(idProduto.Text), Int32.Parse(idAlmoxarifado.Text), Int32.Parse(quantidade.Text));
                } catch (Exception exp) {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                Controller.Alterar(saldo.Id, Int32.Parse(idProduto.Text), Int32.Parse(idAlmoxarifado.Text), Int32.Parse(quantidade.Text));
            }

            ListaSaldo.Refresh();
            this.Close();
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
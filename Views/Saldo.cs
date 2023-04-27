namespace Views
{
    class Saldo : Form
    {
        Button cancelar = new Button();
        Button confirmar = new Button();
        Label idProdutoLabel = new Label();
        ComboBox comboBoxProduto = new ComboBox();
        Label idAlmoxarifadoLabel = new Label();
        ComboBox comboBoxAlmoxarifado = new ComboBox();
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

            idProdutoLabel.Text = "Produto:";
            idProdutoLabel.Location = new Point(10, 10);
            
            comboBoxProduto.Location = new Point(110, 10);
            comboBoxProduto.Size = new Size(100, 18);
            comboBoxProduto.TabIndex = 0;
            this.setComboBoxProduto();
            comboBoxProduto.Text = "Produto";

            idAlmoxarifadoLabel.Text = "Almoxarifado:";
            idAlmoxarifadoLabel.Location = new Point(10, 50);
            idAlmoxarifadoLabel.Size = new Size(100, 50);

            comboBoxAlmoxarifado.Location = new Point(110, 50);
            comboBoxAlmoxarifado.Size = new Size(100, 18);
            comboBoxAlmoxarifado.TabIndex = 0;
            this.setComboBoxAlmoxarifado();
            comboBoxAlmoxarifado.Text = "Almoxarifdo";

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
            Controls.Add(comboBoxProduto);
            Controls.Add(idAlmoxarifadoLabel);
            Controls.Add(comboBoxAlmoxarifado);
            Controls.Add(quantidadeLabel);
            Controls.Add(quantidade);
        }

        public void Alterar(int id)
        {
            saldo = Controller.GetById(id);

            if (saldo != null)
            {
                int res = comboBoxProduto.FindStringExact(saldo.Produto.Nome);
                comboBoxProduto.SelectedIndex = res;

                res = comboBoxAlmoxarifado.FindStringExact(saldo.Almoxarifado.Nome);
                comboBoxAlmoxarifado.SelectedIndex = res;

                quantidade.Text = saldo.Quantidade.ToString();
            }
        }
        public void Confirmar_Click(object sender, EventArgs e)
        {
            Models.SaldoFormView produto = (comboBoxProduto.SelectedItem as Models.SaldoFormView);
            Models.SaldoFormView almoxarifado = (comboBoxAlmoxarifado.SelectedItem as Models.SaldoFormView);
            if (saldo == null)
            {
                try
                {
                    Controller.Criar(produto.Id, almoxarifado.Id, Int32.Parse(quantidade.Text));
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                Controller.Alterar(saldo.Id, produto.Id, almoxarifado.Id, Int32.Parse(quantidade.Text));
            }

            MessageBox.Show("Cadastrado com sucesso!");

            ListaSaldo.Refresh();
            this.Close();
        }

        private void setComboBoxProduto()
        {

            comboBoxProduto.Items.Clear();
            List<Models.SaldoFormView> listProduto = Controller.ListarProduto().Select(p => new Models.SaldoFormView(p.Id, p.Nome)).ToList();

            listProduto.ForEach(produto =>
            {
                comboBoxProduto.Items.Add(produto);
            });
        }
        private void setComboBoxAlmoxarifado()
        {
            comboBoxAlmoxarifado.Items.Clear();
            List<Models.SaldoFormView> listAlmoxarifado = Controller.ListarAlmoxarifado().Select(p => new Models.SaldoFormView(p.Id, p.Nome)).ToList();;

            listAlmoxarifado.ForEach(almoxarifado =>
            {
                comboBoxAlmoxarifado.Items.Add(almoxarifado);
            });
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
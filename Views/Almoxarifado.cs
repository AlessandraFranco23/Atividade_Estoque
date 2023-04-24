namespace Views
{
    class Almoxarifado : Form
    {
        Button cancelar = new Button();
        Button confirmar = new Button();
        Label nomeAlmoxarifadoLabel = new Label();
        TextBox nomeAlmoxarifado = new TextBox();
        private Controllers.Almoxarifado controller;
        private ListaAlmoxarifado listaAlmoxarifado;
        private Models.Almoxarifado almoxarifado;

        public Almoxarifado(Controllers.Almoxarifado controller, ListaAlmoxarifado listaAlmoxarifado)
        {
            this.controller = controller;
            this.listaAlmoxarifado = listaAlmoxarifado;
        }

        public void FormLayout()
        {
            this.Name = "ALMOXARIFADO";
            this.Text = "Cadastro de almoxarifado";
            this.Size = new Size(450, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            nomeAlmoxarifadoLabel.Text = "Nome:";
            nomeAlmoxarifadoLabel.Location = new Point(10, 10);

            nomeAlmoxarifado.Location = new Point(110, 10);

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
            Controls.Add(nomeAlmoxarifadoLabel);
            Controls.Add(nomeAlmoxarifado);
        }

        public void Alterar(int id)
        {
            almoxarifado = controller.GetById(id);

            if (almoxarifado != null)
            {
                nomeAlmoxarifado.Text = almoxarifado.Nome;
            }
        }
        public void Confirmar_Click(object sender, EventArgs e)
        {
            if (almoxarifado == null)
            {
                controller.Criar(nomeAlmoxarifado.Text);
            }
            else
            {
                controller.Alterar(almoxarifado.Id, nomeAlmoxarifado.Text);
            }

            listaAlmoxarifado.Refresh();
            this.Close();
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
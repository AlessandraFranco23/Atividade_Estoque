namespace Views
{
    class Lista : Form
    {
        Button criar = new Button();
        Button alterar = new Button();
        Button excluir = new Button();
        Button Voltar = new Button();

        private DataGridView GridView = new DataGridView();
        private Controllers.Produto controller;
        private Models.Context context;

        public Lista(Models.Context context)
        {
            this.context = context;
            controller = new Controllers.Produto();
        }

        public void FormLayout()
        {
            this.Name = "LISTA DE PRODUTOS";
            this.Text = "Lista de produtos";
            this.Size = new Size(450, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            criar.Text = "criar";
            criar.Name = "criar";
            criar.Location = new Point(10, 325);
            criar.Height = 20;
            criar.Width = 100;
            criar.Click += new EventHandler(Criar_Click);

            alterar.Text = "Alterar";
            alterar.Name = "alterar";
            alterar.Location = new Point(110, 325);
            alterar.Height = 20;
            alterar.Width = 100;
            alterar.Click += new EventHandler(Alterar_Click);

            excluir.Text = "Excluir";
            excluir.Name = "Excluir";
            excluir.Location = new Point(210, 325);
            excluir.Height = 20;
            excluir.Width = 100;
            excluir.Click += new EventHandler(Excluir_Click);

            Voltar.Text = "Voltar";
            Voltar.Name = "Voltar";
            Voltar.Location = new Point(310, 325);
            Voltar.Height = 20;
            Voltar.Width = 100;
            Voltar.Click += new EventHandler(Voltar_Click);

            Controls.Add(criar);
            Controls.Add(alterar);
            Controls.Add(excluir);
            Controls.Add(Voltar);
            SetupDataGridView();
            foreach (var item in controller.Listar().Select(p => p.toRow()))
            {
                GridView.Rows.Add(item);
            }

        }


        private void SetupDataGridView()
        {
            this.Controls.Add(GridView);

            GridView.ColumnCount = 3;

            GridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            GridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            GridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(GridView.Font, FontStyle.Bold);

            GridView.Name = "GridView";
            GridView.Location = new Point(8, 8);
            GridView.Size = new Size(500, 250);
            GridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            GridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            GridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            GridView.GridColor = Color.Black;
            GridView.RowHeadersVisible = false;

            GridView.Columns[0].Name = "Id";
            GridView.Columns[1].Name = "Nome";
            GridView.Columns[2].Name = "Preco";

            GridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            GridView.MultiSelect = false;
            GridView.Dock = DockStyle.Fill;

            // GridView.CellFormatting += new
            //     DataGridViewCellFormattingEventHandler(
            //     GridView_CellFormatting);
        }

        public void Refresh()
        {
            GridView.Rows.Clear();
            foreach (var item in controller.Listar().Select(p => p.toRow()))
            {
                GridView.Rows.Add(item);
            }
        }
        public void Criar_Click(object sender, EventArgs e)
        {

            Produto f4 = new Produto(controller, this);
            f4.FormLayout();
            f4.Show();
        }
        private void Alterar_Click(object sender, EventArgs e)
        {
            if (GridView.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.GridView.SelectedRows[0];
                string id = (string)row.Cells["Id"].Value;
                Produto f5 = new Produto(controller, this);
                f5.FormLayout();
                f5.Alterar(Int32.Parse(id));
                f5.Show();
            }
            else
            {
                MessageBox.Show("Selecione um produto!");
            }

        }
        private void Excluir_Click(object sender, EventArgs e)
        { 
            if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {   
                DataGridViewRow row = this.GridView.SelectedRows[0];
                string id = (string)row.Cells["Id"].Value;
                controller.Excluir(Int32.Parse(id));
                this.Refresh();
            }
            
        }
        private void Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

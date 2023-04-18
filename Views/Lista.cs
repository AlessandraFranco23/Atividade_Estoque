namespace Views
{
    class Lista : Form
    {
        Button criar = new Button();  
        Button alterar = new Button(); 
        Button excluir = new Button();  
        Button voltar = new Button();
    public void FormLayout()
    {
        this.Name = "LISTA DE PRODUTOS";
        this.Text = "Lista de produtos";
        this.Size = new Size(450,450);
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
        alterar.Click  += new EventHandler(Alterar_Click); 

        excluir.Text = "Excluir";
        excluir.Name = "Excluir";
        excluir.Location = new Point(210, 325);  
        excluir.Height = 20;  
        excluir.Width = 100;  
        excluir.Click += new EventHandler(Excluir_Click); 

        voltar.Text = "Voltar";
        voltar.Name = "Voltar";
        voltar.Location = new Point(310, 325);  
        voltar.Height = 20;  
        voltar.Width = 100;  
        voltar.Click  += new EventHandler(Voltar_Click); 
        
        Controls.Add(criar);
        Controls.Add(alterar);
        Controls.Add(excluir);
        Controls.Add(voltar);
    }
    

    public void Criar_Click(object sender, EventArgs e) 
    {
        Produto f4 = new Produto();
        f4.FormLayout();
        f4.Show();
    }
     private void Alterar_Click(object sender, EventArgs e)  
    {    
        Produto f5 = new Produto();
        f5.FormLayout();
        f5.Show();  
    }
    private void Excluir_Click(object sender, EventArgs e)  
    {   
        MessageBox.Show("Deseja realmente excluir?");  
    }
     private void Voltar_Click(object sender, EventArgs e)  
    {    
        this.Close();  
    }

  }
}

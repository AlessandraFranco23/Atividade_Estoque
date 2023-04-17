namespace Views
{
    public class Menu: Form
    {

        Button produto = new Button();  
        Button sair  = new Button();  


 public void FormLayout()
    {
        this.Name = "MENU";
        this.Text = "Menu Estoque";
        this.Size = new Size(450,450);
        this.StartPosition = FormStartPosition.CenterScreen;

        produto.Text = "Produto";
        produto.Name = "Produto";
        produto.Location = new Point(110, 120);  
        produto.Height = 40;  
        produto.Width = 300;  
        produto.Click += new EventHandler(Produto_Click); 
        
        Controls.Add(produto);
        // Controls.Add(cancelButton);


    }
    

    public void Produto_Click(object sender, EventArgs e) {
        Lista f3 = new Lista(); // Instantiate a Form3 object.
        f3.Show(); // Show Form3 and
        // this.Close(); // closes the Form2 instance.
    }}
}
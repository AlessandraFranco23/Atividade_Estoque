using Views;

namespace Projeto_Estoque;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>

    public static Menu form = new Menu();
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        // Application.EnableVisualStyles();
        form.FormLayout();
        Application.Run(form);
    }    
}
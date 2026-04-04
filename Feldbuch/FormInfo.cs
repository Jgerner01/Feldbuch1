namespace Feldbuch;

public partial class FormInfo : Form
{
    public FormInfo()
    {
        InitializeComponent();

        lblName.Text      = Application.ProductName;
        lblVersion.Text   = $"Version {Application.ProductVersion}";
        lblCopyright.Text = "© 2026 Johann Gerner";
        lblAutor.Text     = "Autor:   Johann Gerner";
    }

    private void btnOK_Click(object? sender, EventArgs e) => Close();
}

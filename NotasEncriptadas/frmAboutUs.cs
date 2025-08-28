namespace NotasEncriptadas
{
    public partial class frmAboutUs : Form
    {
        public frmAboutUs()
        {
            InitializeComponent();
        }

        private void frmAboutUs_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "Programa de cifrado de texto versión\n"
                + Application.ProductVersion + ",\n"
                + "se pueden enviar sugerencias vía correo electrónico\n"
                + "a eduardo.ramirez.desarrollo@gmail.com\n"
                + "así como cualquier error que se localice.\n"
                + "Autor: Eduardo Ramírez.";
        }
    }
}

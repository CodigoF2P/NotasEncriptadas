using NotasEncriptadas.Settings;

namespace NotasEncriptadas
{
    public partial class frmEMail : Form
    {
        public frmEMail()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtEMail.Text == "")
            {
                MessageBox.Show("Por favor escribir su correo para darle segumiento a su reporte.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Por favor escribir su nombre para saber a quien dirigirme durante su reporte.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (txtBody.Text == "")
            {
                MessageBox.Show("El correo no puede ir sin informacion.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (clHelpers.bSendEMail("Aplicacion Escritorio P00002",
                "Correo: " + txtEMail.Text + "\nNombre: " + txtName.Text + "\nVersion: " +
                Application.ProductVersion + "\nCuerpo Correo:\n" + txtBody.Text))
            {
                MessageBox.Show("El correo fue enviado con exito.", "Enviar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}

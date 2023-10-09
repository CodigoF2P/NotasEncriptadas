namespace NotasEncriptadas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Boolean showPassword = false;
        private Boolean showPIN = false;

        private void btnShowPassword_Click(object sender, EventArgs e)
        {//Ocultar o mostrar la clave
            if (showPassword)
            {
                txtPassword.PasswordChar = '*';
                showPassword = false;
            }
            else
            {
                txtPassword.PasswordChar = '\0';
                showPassword = true;
            }
        }

        private void btnPIN_Click(object sender, EventArgs e)
        {//Ocultar o mostrar el PIN
            if (showPIN)
            {
                txtPIN.PasswordChar = '*';
                showPIN = false;
            }
            else
            {
                txtPIN.PasswordChar = '\0';
                showPIN = true;
            }
        }

        private void Form1_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {//Información de la aplicación
            MessageBox.Show("La clave debe contener mínimo 8 caracteres y máximo 50.\n" +
                "El PIN debe contener mínimo 4 números y máximo 12.\n" +
                "La clave y el PIN sirven para codificar y decodificar el texto.\n" +
                "Si se introduce algún dato mal al abrir el archivo, \n" +
                "se abrirá el archivo pero no se decodificará correctamente.\n" +
                "Se pueden crear archivos con distintas contraseñas y PIN,\n" +
                "pero cada archivo solo se decodificar de manera correcta\n" +
                "con la contraseña y el PIN con el cual fue guardado.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
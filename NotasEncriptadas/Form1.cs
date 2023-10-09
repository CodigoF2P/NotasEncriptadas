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
        {//Informaci�n de la aplicaci�n
            MessageBox.Show("La clave debe contener m�nimo 8 caracteres y m�ximo 50.\n" +
                "El PIN debe contener m�nimo 4 n�meros y m�ximo 12.\n" +
                "La clave y el PIN sirven para codificar y decodificar el texto.\n" +
                "Si se introduce alg�n dato mal al abrir el archivo, \n" +
                "se abrir� el archivo pero no se decodificar� correctamente.\n" +
                "Se pueden crear archivos con distintas contrase�as y PIN,\n" +
                "pero cada archivo solo se decodificar de manera correcta\n" +
                "con la contrase�a y el PIN con el cual fue guardado.", "Informaci�n",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
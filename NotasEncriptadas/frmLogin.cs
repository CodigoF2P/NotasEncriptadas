using NotasEncriptadas.Settings;

namespace NotasEncriptadas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            //Informacion de ayuda
            this.ttMessage.SetToolTip(this.txtPassword, "La contraseña debe contener mínimo 8 caracteres y máximo 50.");
            this.ttMessage.SetToolTip(this.txtPIN, "El PIN debe contener mínimo 4 caracteres y máximo 12.");
        }

        private Boolean showPassword = false;
        private Boolean showPIN = false;

        private void btnShowPassword_Click(object sender, EventArgs e)
        {//Ocultar o mostrar la contraseña
            if (showPassword)
                txtPassword.PasswordChar = '*';
            else
                txtPassword.PasswordChar = '\0';

            showPassword = !showPassword;
        }

        private void btnShowPIN_Click(object sender, EventArgs e)
        {//Ocultar o mostrar el PIN
            if (showPIN)
                txtPIN.PasswordChar = '-';
            else
                txtPIN.PasswordChar = '\0';

            showPIN = !showPIN;
        }

        private void Form1_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {//Información de la aplicación
            MessageBox.Show("La contraseña y el PIN sirven para codificar y decodificar el texto.\n" +
                "Si se introduce algún dato mal al abrir el archivo, \n" +
                "se abrirá el archivo pero no se decodificará correctamente.\n" +
                "Se pueden crear archivos con distintas contraseñas y PIN,\n" +
                "pero cada archivo solo se decodificar de manera correcta\n" +
                "con la contraseña y el PIN con el cual fue guardado.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {//Crear nuevo archivo codificado
            if (ValidateDataLength())
                OpenNotes(false);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {//Abrir archivo codificado
            if (ValidateDataLength())
                OpenNotes(true);
        }

        private void txtPIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOpen.PerformClick();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOpen.PerformClick();
        }

        private bool ValidateDataLength()
        {//Verdadero = Longitud correcta
            if (txtPassword.Text.Length < 8)
                MessageBox.Show("La contraseña debe contener mínimo 8 caracteres y máximo 50.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (txtPIN.Text.Length < 4)
                MessageBox.Show("El PIN debe contener mínimo 4 números y máximo 12. Solo pueden ser números.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                return true;
            return false;//El largo se valida dentro de las cajas de texto
        }

        private void OpenNotes(bool bOpenFile)
        {//Abrir formulario de notas
            try
            {
                bool bOpenForm = true;
                frmTextNotes frmText = new frmTextNotes();
                //Guarda la contraseña y el PIN para codificar el archivo
                clGlobalSetting.encryptionPassword = txtPassword.Text;
                clGlobalSetting.encryptionPIN = txtPIN.Text;
                clGlobalSetting.changeSettings = false;

                if (bOpenFile)
                {
                    bOpenForm = false;
                    //Buscar el archivo codificado
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        //openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Filter = "Text files (*.llave)|*.llave";
                        openFileDialog.FilterIndex = 2;
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            bOpenForm = true;
                            //Obtiene la ruta del archivo y la guarda
                            clGlobalSetting.filePath = openFileDialog.FileName;
                            //Obtiene el texto codificado y lo guarda
                            clGlobalSetting.encodedText = System.IO.File.ReadAllText(clGlobalSetting.filePath);
                        }
                    }
                }
                clGlobalSetting.openFile = bOpenFile;

                //Abre la ventana donde se guarda la información a codificar
                if(bOpenForm)
                {
                    this.Hide();
                    frmText.Show();
                }
            }
            catch (Exception ex)
            {//Captura error
                MessageBox.Show("Error: " + System.Environment.NewLine + System.Environment.NewLine + ex.GetType().ToString() + System.Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
using NotasEncriptadas.Settings;

namespace NotasEncriptadas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            this.ttMessage.SetToolTip(this.txtPassword, "La clave debe contener m�nimo 8 caracteres y m�ximo 50.");
            this.ttMessage.SetToolTip(this.txtPIN, "El PIN debe contener m�nimo 4 caracteres y m�ximo 12.");
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
                txtPIN.PasswordChar = '-';
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
            MessageBox.Show("La clave y el PIN sirven para codificar y decodificar el texto.\n" +
                "Si se introduce alg�n dato mal al abrir el archivo, \n" +
                "se abrir� el archivo pero no se decodificar� correctamente.\n" +
                "Se pueden crear archivos con distintas contrase�as y PIN,\n" +
                "pero cada archivo solo se decodificar de manera correcta\n" +
                "con la contrase�a y el PIN con el cual fue guardado.", "Informaci�n",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)//Crear nuevo archivo codificado
        {
            try
            {
                frmTextNotes frmText = new frmTextNotes();
                if (txtPassword.Text.Length < 8)
                {
                    MessageBox.Show("La clave debe contener m�nimo 8 caracteres y m�ximo 50.", "Informaci�n",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtPIN.Text.Length < 4)
                    {
                        MessageBox.Show("El PIN debe contener m�nimo 4 n�meros y m�ximo 12. " +
                            "Solo pueden ser n�meros.",
                            "Informaci�n", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Guarda la clave y el PIN para codificar el archivo
                        clGlobalSetting.encryptionPassword = txtPassword.Text;
                        clGlobalSetting.encryptionPIN = txtPIN.Text;

                        //Abre la ventana donde se guarda la informaci�n a codificar
                        clGlobalSetting.openFile = false;
                        this.Hide();
                        frmText.Show();
                    }
                }
            }
            catch (Exception ex)
            {//Captura error
                MessageBox.Show("Error: " + System.Environment.NewLine + System.Environment.NewLine +
                    ex.GetType().ToString() + System.Environment.NewLine + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {//Abrir archivo codificado
            try
            {
                frmTextNotes frmText = new frmTextNotes();
                if (txtPassword.Text.Length < 8)
                {
                    MessageBox.Show("La clave debe contener m�nimo 8 caracteres y m�ximo 50.", "Informaci�n",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtPIN.Text.Length < 4)
                    {
                        MessageBox.Show("El PIN debe contener m�nimo 4 n�meros y m�ximo 12. " +
                            "Solo pueden ser n�meros.",
                            "Informaci�n", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Guarda la clave y el PIN para decodificar el archivo
                        clGlobalSetting.encryptionPassword = txtPassword.Text;
                        clGlobalSetting.encryptionPIN = txtPIN.Text;

                        //Buscar el archivo codificado
                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            //openFileDialog.InitialDirectory = "c:\\";
                            openFileDialog.Filter = "Text files (*.llave)|*.llave";
                            openFileDialog.FilterIndex = 2;
                            openFileDialog.RestoreDirectory = true;

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                //Obtiene la ruta del archivo y la guarda
                                clGlobalSetting.filePath = openFileDialog.FileName;

                                //Obtiene el texto codificado y lo guarda
                                clGlobalSetting.encodedText = System.IO.File.ReadAllText(clGlobalSetting.filePath);
                                clGlobalSetting.openFile = true;

                                //Abre la ventana donde se guarda la informaci�n a codificar
                                this.Hide();
                                frmText.Show();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {//Captura error
                MessageBox.Show("Error: " + System.Environment.NewLine + System.Environment.NewLine +
                    ex.GetType().ToString() + System.Environment.NewLine + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
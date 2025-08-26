using NotasEncriptadas.Settings;

namespace NotasEncriptadas
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            //Informacion de ayuda
            this.ttMessage.SetToolTip(this.txtPassword, "La contraseña debe contener mínimo 8 caracteres y máximo 50.");
            this.ttMessage.SetToolTip(this.txtPIN, "El PIN debe contener mínimo 4 caracteres y máximo 12.");
        }

        private Boolean showPassword = false;
        private Boolean showPIN = false;
        public Int16 change;

        private void frmSettings_Load(object sender, EventArgs e)
        {
            clGlobalSetting.changeSettings = false;
            switch (change)
            {
                case 1://Nuevo archivo
                    this.Text = "Nuevo archivo";
                    btnOk.Text = "&Nuevo";
                    break;

                case 2://Abrir archivo
                    this.Text = "Abrir archivo";
                    btnOk.Text = "&Abrir";
                    break;

                case 3://Cambiar Contraseña
                    this.MaximumSize = new Size(236, 125);
                    this.MinimumSize = new Size(236, 125);
                    this.Size = new Size(236, 125);
                    lblPIN.Visible = false;
                    txtPIN.Visible = false;
                    btnShowPIN.Visible = false;

                    btnOk.Location = new Point(73, 56);
                    this.Text = "Cambiar Contraseña";
                    break;

                case 4://Cambiar PIN
                    this.MaximumSize = new Size(236, 125);
                    this.MinimumSize = new Size(236, 125);
                    this.Size = new Size(236, 125);
                    lblPassword.Visible = false;
                    txtPassword.Visible = false;
                    btnShowPassword.Visible = false;

                    lblPIN.Location = new Point(12, 9);
                    txtPIN.Location = new Point(12, 27);
                    btnShowPIN.Location = new Point(184, 27);
                    btnOk.Location = new Point(73, 56);
                    this.Text = "Cambiar PIN";
                    break;

                default:
                    break;
            }

        }

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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk.PerformClick();
        }

        private void txtPIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk.PerformClick();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool bClose = false;
            switch (change)
            {
                case 1://Nuevo archivo
                    if (txtPassword.Text.Length < 8)
                        MessageBox.Show("La contraseña debe contener mínimo 8 caracteres y máximo 50.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (txtPIN.Text.Length < 4)
                        MessageBox.Show("El PIN debe contener mínimo 4 números y máximo 12. Solo pueden ser números.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        clGlobalSetting.encryptionPassword = txtPassword.Text;
                        clGlobalSetting.encryptionPIN = txtPIN.Text;
                        clGlobalSetting.changeSettings = true;
                        clGlobalSetting.openFile = false;
                        bClose = true;
                    }
                    break;

                case 2://Abrir archivo
                    if (txtPassword.Text.Length < 8)
                        MessageBox.Show("La contraseña debe contener mínimo 8 caracteres y máximo 50.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (txtPIN.Text.Length < 4)
                        MessageBox.Show("El PIN debe contener mínimo 4 números y máximo 12. Solo pueden ser números.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {//Buscar el archivo codificado
                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.Filter = "Text files (*.llave)|*.llave";
                            openFileDialog.FilterIndex = 2;
                            openFileDialog.RestoreDirectory = true;

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                //Obtiene la ruta del archivo y la guarda
                                clGlobalSetting.filePath = openFileDialog.FileName;
                                //Obtiene el texto codificado y lo guarda
                                clGlobalSetting.encodedText = System.IO.File.ReadAllText(clGlobalSetting.filePath);

                                clGlobalSetting.encryptionPassword = txtPassword.Text;
                                clGlobalSetting.encryptionPIN = txtPIN.Text;
                                clGlobalSetting.changeSettings = true;
                                clGlobalSetting.openFile = true;
                                bClose = true;
                            }
                        }
                    }

                    break;

                case 3://Cambiar Contraseña
                    if (txtPassword.Text.Length < 8)
                        MessageBox.Show("La contraseña debe contener mínimo 8 caracteres y máximo 50.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        clGlobalSetting.encryptionPassword = txtPassword.Text;
                        clGlobalSetting.changeSettings = true;
                        bClose = true;
                    }
                    break;

                case 4://Cambiar PIN
                    if (txtPIN.Text.Length < 4)
                        MessageBox.Show("El PIN debe contener mínimo 4 números y máximo 12. Solo pueden ser números.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        clGlobalSetting.encryptionPIN = txtPIN.Text;
                        clGlobalSetting.changeSettings = true;
                        bClose = true;
                    }
                    break;

                default:
                    break;
            }

            if(bClose)
                this.Close();
        }
    }
}

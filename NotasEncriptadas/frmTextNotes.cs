using EncriptarCadenasTexto;
using NotasEncriptadas.Settings;

namespace NotasEncriptadas
{
    public partial class frmTextNotes : Form
    {
        public frmTextNotes()
        {
            InitializeComponent();
        }
        private string savedText = "";

        private void frmTextNotes_Load(object sender, EventArgs e)
        {
            clGlobalSetting.changeSettings = true;
            if (clGlobalSetting.openFile)//Archivo abierto
                OpenNote(false);
            else//Archivo nuevo
                NewNote(false);
        }

        private void frmTextNotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//Cierra la aplicacion
        }

        private void frmTextNotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Aun se puede cancelar el cierre del formulario (Evento)
            if (ValidateChangesMade())
                if (MessageBox.Show("Hay cambios sin guardara y seran descartados ¿Quieres cerrar la aplicacion?", "Informacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) != DialogResult.Yes)//Si hay cambios sin guardar en el archivo, pregunta si los descarta
                    e.Cancel = true;//Cancelar el evento de cierre
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            bool bFileNew = true;
            //Revisar si el archivo actual tiene cambios
            if (ValidateChangesMade())
            {
                if (MessageBox.Show("Hay cambios sin guardara y seran descartados ¿Quieres crear un nuevo archivo?", "Informacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)//Si hay cambios sin guardar en el archivo, pregunta si los descarta
                    bFileNew = true;
                else
                    bFileNew = false;
            }
            if (bFileNew)
                NewNote(true);
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            bool bOpenAnotherFile = true;
            //Revisar si el archivo actual tiene cambios
            if (ValidateChangesMade())
            {
                if (MessageBox.Show("Hay cambios sin guardara y seran descartados ¿Quieres abrir otro archivo?", "Informacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)//Si hay cambios sin guardar en el archivo, pregunta si los descarta
                    bOpenAnotherFile = true;
                else
                    bOpenAnotherFile = false;
            }
            if (bOpenAnotherFile)
                OpenNote(true);
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            if (SaveFile())
                MessageBox.Show("Cambios guardados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsmiSaveClose_Click(object sender, EventArgs e)
        {
            if (SaveFile())
                this.Close();
            else
                MessageBox.Show("No se pudo guardar el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            this.Close();//Cierra el formulario
        }

        private void tsmiPassword_Click(object sender, EventArgs e)
        {
            OpenFormSettings(3);
        }

        private void tsmiNIP_Click(object sender, EventArgs e)
        {
            OpenFormSettings(4);
        }

        private void tsmiEmail_Click(object sender, EventArgs e)
        {
            frmEMail frmEmail = new frmEMail();
            frmEmail.ShowDialog();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            frmAboutUs frmAbout = new frmAboutUs();
            frmAbout.ShowDialog();
        }

        private void tsmiDonations_Click(object sender, EventArgs e)
        {
            frmDonation frmDonations = new frmDonation();
            frmDonations.ShowDialog();
        }

        private void OpenNote(bool bAnotherFile)
        {
            if (bAnotherFile)//Abrir el formulario de login para capturar informacion, abrir otro archivo
                OpenFormSettings(2);
            if (clGlobalSetting.changeSettings)
            {
                FileInfo fInfo = new FileInfo(clGlobalSetting.filePath);
                this.Text = "Encriptar nota (" + Path.GetFileNameWithoutExtension(fInfo.Name) + ")";
                txtEncryptText.Text = DecryptTextFile();
                savedText = txtEncryptText.Text;
            }
            clGlobalSetting.changeSettings = false;
        }

        private void NewNote(bool bCaptureInformation)
        {
            if (bCaptureInformation)//Abrir el formulario de login para capturar: clave y contraseña
                OpenFormSettings(1);
            if (clGlobalSetting.changeSettings)
            {
                this.Text = "Encriptar nota (NUEVA)";
                txtEncryptText.Text = "";
                savedText = "";
                clGlobalSetting.openFile = false;
            }
            clGlobalSetting.changeSettings = false;
        }

        /// <summary>
        /// Cambiar los datos de la endriptacion del archivo.
        /// Generar un nuevo archivo, abrir un archivo, cambiar contraseña o cambiar PIN.
        /// </summary>
        /// <param name="iChange">1: Nuevo archivo. 2: Abrir archivo. 3: Cambiar Contraseña. 4: Cambiar PIN. </param>
        private void OpenFormSettings(Int16 iChange)
        {
            frmSettings frmChanges = new frmSettings();
            frmChanges.change = iChange;
            frmChanges.ShowDialog();
        }

        private string DecryptTextFile()
        {
            clDecryptText objDecrypt = new clDecryptText();
            return objDecrypt.Decrypt(clGlobalSetting.encodedText, clGlobalSetting.encryptionPIN, clGlobalSetting.encryptionPassword);
        }

        private Boolean ValidateChangesMade()
        {//Validar que no halla cambios sin guardar
            if (clGlobalSetting.openFile)//Archivo abierto
                return (savedText != txtEncryptText.Text);
            else//Archivo nuevo 
                return (txtEncryptText.Text != "");
        }

        private Boolean SaveFile()
        {
            StreamWriter swFile;
            string sCodedText;
            clEncryptText objEncrypt = new clEncryptText();

            if (!clGlobalSetting.openFile)
            {//Abri explorador de archivo y ponerle nombre para encriptarlo y guardar
                using (SaveFileDialog sfdSave = new SaveFileDialog())
                {
                    //sfdGuardarArchivo.InitialDirectory = "c:\\";
                    sfdSave.FileName = "ArchivoProtegido";
                    sfdSave.Filter = "Text files (*.llave)|*.llave";
                    sfdSave.DefaultExt = ".llave";
                    sfdSave.RestoreDirectory = true;

                    //Abre el guardador de archivos
                    if (sfdSave.ShowDialog() == DialogResult.OK)
                    {
                        clGlobalSetting.filePath = sfdSave.FileName;
                        FileInfo fInfo = new FileInfo(sfdSave.FileName);
                        this.Text = "Encriptar nota (" + Path.GetFileNameWithoutExtension(fInfo.Name) + ")";
                    }
                    else
                        return false;
                }
            }

            //Guardar archivo
            try
            {
                swFile = new StreamWriter(clGlobalSetting.filePath, false, System.Text.Encoding.Default);
                sCodedText = objEncrypt.Encrypt(txtEncryptText.Text, clGlobalSetting.encryptionPIN, clGlobalSetting.encryptionPassword);
                swFile.Write(sCodedText);
                swFile.Flush();
                swFile.Close();
                clGlobalSetting.openFile = true;
                savedText = txtEncryptText.Text;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar fichero de texto: " + System.Environment.NewLine +
                    System.Environment.NewLine + ex.GetType().ToString() +
                    System.Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
    }
}

using EncriptarCadenasTexto;
using NotasEncriptadas.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (clGlobalSetting.openFile)//Archivo abierto
            {
                FileInfo fiArchivo = new FileInfo(clGlobalSetting.filePath);
                this.Text = this.Text + " (" + Path.GetFileNameWithoutExtension(fiArchivo.Name) + ")";
                txtEncryptText.Text = DesencriptarArchivoTexto(clGlobalSetting.filePath);
                savedText = txtEncryptText.Text;
            }
            else//Archivo nuevo
                this.Text = this.Text + " (NUEVA)";
        }

        private void frmTextNotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Aun se puede cancelar el cierre del formulario (Evento)
            if (ValidarCambiosEchos())
                if (MessageBox.Show("Hay cambios sin guardara y seran descartados ¿Quieres cerrar la aplicacion?", "Informacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) != DialogResult.Yes)//Si hay cambios sin guardar en el archivo, pregunta si los descarta
                    e.Cancel = true;//Cancelar el evento de cierre
        }

        private string DesencriptarArchivoTexto(string filePath)
        {
            clDecryptText objDecrypt = new clDecryptText();
            return objDecrypt.Decrypt(clGlobalSetting.encodedText, clGlobalSetting.encryptionPIN, clGlobalSetting.encryptionPassword);
        }

        private Boolean ValidarCambiosEchos()
        {//Validar que no halla cambios sin guardar
            if (clGlobalSetting.openFile)//Archivo abierto
                return (savedText != txtEncryptText.Text);
            else//Archivo nuevo
                return (txtEncryptText.Text != "");
        }

        private void frmTextNotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//Cierra la aplicacion
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            this.Close();//Cierra el formulario
        }

        private void tsmiSaveClose_Click(object sender, EventArgs e)
        {
            if (GuardarArchivo())
                this.Close();
            else
                MessageBox.Show("No se pudo guardar el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Boolean GuardarArchivo()
        {
            StreamWriter swFicheroTexto;
            string sTextoCodificado;
            clEncryptText objEncrypt = new clEncryptText();

            if (clGlobalSetting.openFile)
            {//Guardar archivo abierto
                try
                {
                    swFicheroTexto = new StreamWriter(clGlobalSetting.filePath, false, System.Text.Encoding.Default);
                    sTextoCodificado = objEncrypt.Encrypt(txtEncryptText.Text, clGlobalSetting.encryptionPIN, clGlobalSetting.encryptionPassword);
                    swFicheroTexto.Write(sTextoCodificado);
                    swFicheroTexto.Flush();
                    swFicheroTexto.Close();
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
            else
            {//Abri explorador de archivo y ponerle nombre para encriptarlo y guardar
                using (SaveFileDialog sfdGuardarArchivo = new SaveFileDialog())
                {
                    //sfdGuardarArchivo.InitialDirectory = "c:\\";
                    sfdGuardarArchivo.FileName = "ArchivoProtegido";
                    sfdGuardarArchivo.Filter = "Text files (*.llave)|*.llave";
                    sfdGuardarArchivo.DefaultExt = ".llave";
                    sfdGuardarArchivo.RestoreDirectory = true;

                    //Abre el guardador de archivos
                    if (sfdGuardarArchivo.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            swFicheroTexto = new StreamWriter(sfdGuardarArchivo.FileName, false, System.Text.Encoding.Default);
                            sTextoCodificado = objEncrypt.Encrypt(txtEncryptText.Text, clGlobalSetting.encryptionPIN, clGlobalSetting.encryptionPassword);
                            swFicheroTexto.Write(sTextoCodificado);
                            swFicheroTexto.Flush();
                            swFicheroTexto.Close();
                            clGlobalSetting.openFile = true;
                            clGlobalSetting.filePath = sfdGuardarArchivo.FileName;
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
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            if (GuardarArchivo())
                MessageBox.Show("Cambios guardados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

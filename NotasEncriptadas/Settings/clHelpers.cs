using System.Net;
using System.Net.Mail;

namespace NotasEncriptadas.Settings
{
    internal class clHelpers
    {
        private static string sSendMailAddress = "eduardo.ramirez.desarrollo@gmail.com";
        private static string sEmail = "help.desk.programa@outlook.com";//"help.desk.programa@gmail.com";
        private static string sPassword = "password2022.";

        public static Boolean bSendEMail(string sAsunto, string sCuerpoCorreo)
        {
            try
            {
                MailMessage mCorreo = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.office365.com");

                //Método de cifrado: STARTTLS
                mCorreo.From = new MailAddress(sEmail);//Correo de salida
                //mCorreo.From = new MailAddress(sCorreoSalida, "Mesa de Ayuda", System.Text.Encoding.UTF8);//Correo de salida
                mCorreo.To.Add(sSendMailAddress);//Correo destino
                mCorreo.Subject = sAsunto; //Asunto. Aplicacion Escritorio 00001
                mCorreo.Body = sCuerpoCorreo; //Mensaje del correo. Correo de quien envia, nombre de la persona que envia el correo, version de la aplicacion, cuerpo del correo

                //mCorreo.IsBodyHtml = true;
                //mCorreo.Priority = MailPriority.Normal;
                //Adjuntos:
                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment(lblLocation.Text);
                //mCorreo.Attachments.Add(attachment);

                //smtp.UseDefaultCredentials = false;
                //smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
                smtp.Port = 587; //Puerto de salida
                smtp.Credentials = new NetworkCredential(sEmail, sPassword);//Cuenta de correo
                smtp.EnableSsl = true;
                //smtp.UseDefaultCredentials = false;

                //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                smtp.Send(mCorreo);

                return true;
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("Error al correo: " + System.Environment.NewLine +
                    System.Environment.NewLine + ex.GetType().ToString() +
                    System.Environment.NewLine + ex.Message + System.Environment.NewLine +
                    "Puedes enviar tu correo a: eduardo.ramirez.desarrollo@gmail.com", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al correo: " + System.Environment.NewLine +
                    System.Environment.NewLine + ex.GetType().ToString() +
                    System.Environment.NewLine + ex.Message + System.Environment.NewLine +
                    "Puedes enviar tu correo a: eduardo.ramirez.desarrollo@gmail.com", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}

using System.Security.Cryptography;
using System.Text;

namespace EncriptarCadenasTexto
{
    internal class clEncryptText
    {
        public string Encrypt(string stringOriginalText, string stringConcatenateKey, string stringPasswordAlgorithm)//Metodo para encriptar texto
        {
            string encryptedTextString = CharacterDictionary(stringOriginalText);
            encryptedTextString = RevertString(encryptedTextString);
            encryptedTextString = ConcatenateKey(encryptedTextString, stringConcatenateKey);
            encryptedTextString = encryptedTextString + '.';
            encryptedTextString = RevertString(encryptedTextString);
            encryptedTextString = EncryptTextAES(encryptedTextString, stringPasswordAlgorithm, 256);
            encryptedTextString = UnicodeStandardEncoding(encryptedTextString);
            encryptedTextString = RevertString(encryptedTextString);

            return encryptedTextString;
        }
        private string CharacterDictionary(string stringOriginalText)//Cambiar caracteres
        {
            string processedTextString = "";
            foreach (char c in stringOriginalText)//Recorremos la cadena por caracter
            {
                switch (c)//Comparamos el caracter para cambiarlo por un "sinonimo"
                {
                    case 'l':
                        processedTextString = processedTextString + '1';
                        break;
                    case '1':
                        processedTextString = processedTextString + 'l';
                        break;

                    case 'Z':
                        processedTextString = processedTextString + '2';
                        break;
                    case '2':
                        processedTextString = processedTextString + 'Z';
                        break;

                    case 'E':
                        processedTextString = processedTextString + '3';
                        break;
                    case '3':
                        processedTextString = processedTextString + 'E';
                        break;

                    case 'A':
                        processedTextString = processedTextString + '4';
                        break;
                    case '4':
                        processedTextString = processedTextString + 'A';
                        break;

                    case 's':
                        processedTextString = processedTextString + '5';
                        break;
                    case '5':
                        processedTextString = processedTextString + 's';
                        break;

                    case '9':
                        processedTextString = processedTextString + '6';
                        break;
                    case '6':
                        processedTextString = processedTextString + '9';
                        break;

                    case 'T':
                        processedTextString = processedTextString + '7';
                        break;
                    case '7':
                        processedTextString = processedTextString + 'T';
                        break;

                    case 'b':
                        processedTextString = processedTextString + '8';
                        break;
                    case '8':
                        processedTextString = processedTextString + 'b';
                        break;

                    case 't':
                        processedTextString = processedTextString + '+';
                        break;
                    case '+':
                        processedTextString = processedTextString + 't';
                        break;

                    case ',':
                        processedTextString = processedTextString + '.';
                        break;
                    case '.':
                        processedTextString = processedTextString + ',';
                        break;

                    case 'H':
                        processedTextString = processedTextString + 'x';
                        break;
                    case 'x':
                        processedTextString = processedTextString + 'H';
                        break;

                    case 'a':
                        processedTextString = processedTextString + 'i';
                        break;
                    case 'i':
                        processedTextString = processedTextString + 'a';
                        break;

                    case 'o':
                        processedTextString = processedTextString + '*';
                        break;
                    case '*':
                        processedTextString = processedTextString + 'o';
                        break;

                    case 'e':
                        processedTextString = processedTextString + 'u';
                        break;
                    case 'u':
                        processedTextString = processedTextString + 'e';
                        break;

                    default:
                        processedTextString = processedTextString + c;
                        break;
                }
            }
            return processedTextString;
        }
        private string ConcatenateKey(string stringOriginalText, string stringConcatenateKey)//Concatenar el KEY al string
        {
            string processedTextString = "";
            int flagConcatenateKey = (stringConcatenateKey.Length / 2);
            int counterFlag = 0;
            int counterCharacterKey = 0;

            try
            {
                foreach (char c in stringOriginalText)//Recorremos la cadena por caracter
                {
                    if (flagConcatenateKey == counterFlag)
                    {
                        processedTextString = processedTextString + c + stringConcatenateKey[counterCharacterKey];//Se agrega el caracter que sigue en la cadena inicial, mas el caracter que sigue en el key
                        counterCharacterKey++;
                        counterFlag = 0;
                    }
                    else
                    {
                        processedTextString = processedTextString + c;//Se agrega el caracter que sigue en la cadena inicial
                        counterFlag++;
                    }

                    if (stringConcatenateKey.Length == counterCharacterKey)
                        counterCharacterKey = 0;

                }
            }
            catch { }

            return processedTextString;
        }
        private string RevertString(string stringOriginalText)//Revertir cadenas de texto
        {
            string invertedString = "";

            foreach (char c in stringOriginalText)//Recorremos la cadena por caracter
            {
                invertedString = c + invertedString;//Revertimos la cadena por caracter
            }

            return invertedString;
        }
        private byte[] EncryptionAES(byte[] InformacionInicial, byte[] Key, byte[] IV)
        {
            try
            {
                MemoryStream msInformacion = new MemoryStream();
                Rijndael algoritmoEncriptacion = Rijndael.Create();
                algoritmoEncriptacion.Key = Key;
                algoritmoEncriptacion.IV = IV;
                CryptoStream cs = new CryptoStream(msInformacion, algoritmoEncriptacion.CreateEncryptor(), CryptoStreamMode.Write);//Encripta
                cs.Write(InformacionInicial, 0, InformacionInicial.Length);
                cs.Close();
                byte[] informacionEncriptada = msInformacion.ToArray();
                return informacionEncriptada;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return InformacionInicial;
            }
        }

        private string EncryptTextAES(string Data, string Password, int Bits)
        {
            try
            {
                byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(Data);
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x0, 0x1, 0x2, 0x1C, 0x1D, 0x1E, 0x3, 0x4, 0x5, 0xF, 0x20, 0x21, 0xAD, 0xAF, 0xA4 });
                if (Bits == 128)
                {
                    byte[] encryptedData = EncryptionAES(clearBytes, pdb.GetBytes(16), pdb.GetBytes(16));
                    return Convert.ToBase64String(encryptedData);
                }
                else if (Bits == 192)
                {
                    byte[] encryptedData = EncryptionAES(clearBytes, pdb.GetBytes(24), pdb.GetBytes(16));
                    return Convert.ToBase64String(encryptedData);
                }
                else if (Bits == 256)
                {
                    byte[] encryptedData = EncryptionAES(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                    return Convert.ToBase64String(encryptedData);
                }
                else
                {
                    return String.Concat(Bits);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return String.Concat(Bits);
            }

        }
        private static string UnicodeStandardEncoding(string stringOriginalText)//Codificación estándar de Unicode UTF-8
        {
            byte[] bTextBytes = Encoding.UTF8.GetBytes(stringOriginalText);
            return System.Convert.ToBase64String(bTextBytes);
        }
    }
}
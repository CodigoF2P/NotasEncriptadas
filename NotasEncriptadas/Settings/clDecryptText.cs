using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NotasEncriptadas.Settings
{
    internal class clDecryptText
    {
        public string Decrypt(string encryptedTextString, string stringDeconcatenateKey, string stringPasswordAlgorithm)//Metodo para desencriptar texto
        {
            string decryptedTextString = RevertString(encryptedTextString);
            decryptedTextString = UnicodeStandardDecoding(decryptedTextString);
            decryptedTextString = DecryptTextAES(decryptedTextString, stringPasswordAlgorithm, 256);
            decryptedTextString = RevertString(decryptedTextString);
            decryptedTextString = decryptedTextString.Substring(0, (decryptedTextString.Length - 1));
            decryptedTextString = DeconcatenateKey(decryptedTextString, stringDeconcatenateKey);
            decryptedTextString = RevertString(decryptedTextString);
            decryptedTextString = CharacterDictionary(decryptedTextString);

            return decryptedTextString;
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

        public static string UnicodeStandardDecoding(string encryptedTextString)//Decodificación estándar de Unicode UTF-8
        {
            byte[] bTextBytes = System.Convert.FromBase64String(encryptedTextString);
            return System.Text.Encoding.UTF8.GetString(bTextBytes);
        }

        private string DecryptTextAES(string Data, string Password, int Bits)
        {
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(Data);
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x0, 0x1, 0x2, 0x1C, 0x1D, 0x1E, 0x3, 0x4, 0x5, 0xF, 0x20, 0x21, 0xAD, 0xAF, 0xA4 });
                if (Bits == 128)
                {
                    byte[] decryptedData = DecryptionAES(cipherBytes, pdb.GetBytes(16), pdb.GetBytes(16));
                    return System.Text.Encoding.Unicode.GetString(decryptedData);
                }
                else if (Bits == 192)
                {
                    byte[] decryptedData = DecryptionAES(cipherBytes, pdb.GetBytes(24), pdb.GetBytes(16));
                    return System.Text.Encoding.Unicode.GetString(decryptedData);
                }
                else if (Bits == 256)
                {
                    byte[] decryptedData = DecryptionAES(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                    return System.Text.Encoding.Unicode.GetString(decryptedData);
                }
                else
                {
                    return String.Concat(Bits);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message);
                return String.Concat(Bits);
            }
        }

        private byte[] DecryptionAES(byte[] cipherData, byte[] Key, byte[] IV)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                Rijndael algoritmoEncriptacion = Rijndael.Create();
                algoritmoEncriptacion.Key = Key;
                algoritmoEncriptacion.IV = IV;
                CryptoStream cs = new CryptoStream(ms, algoritmoEncriptacion.CreateDecryptor(), CryptoStreamMode.Write);//Desencripta
                cs.Write(cipherData, 0, cipherData.Length);
                cs.Close();
                byte[] informacionDesencriptada = ms.ToArray();
                return informacionDesencriptada;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message);
                return cipherData;
            }
        }

        private string DeconcatenateKey(string stringTextKeyed, string stringDeconcatenateKey)//Quitar el KEY al string
        {
            string decryptedTextString = "";
            int flagDeconcatenateKey = (stringDeconcatenateKey.Length / 2) + 1;
            int counterFlag = 0;

            foreach (char c in stringTextKeyed)//Recorremos la cadena por caracter
            {
                if (flagDeconcatenateKey == counterFlag)//Quitamos el Key
                {
                    counterFlag = 0;
                }
                else//Agregamos por caracter la cadena original
                {
                    decryptedTextString = decryptedTextString + c;
                    counterFlag++;
                }
            }

            return decryptedTextString;
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
    }
}

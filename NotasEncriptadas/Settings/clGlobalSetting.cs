using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasEncriptadas.Settings
{
    internal class clGlobalSetting
    {
        public static string encryptionPassword = ""; //Contraseña de encripatacion
        public static string encryptionPIN = "";//PIN de encripatacion

        public static string filePath = "";
        public static string encodedText = "";
        
        public static bool openFile = false;
        public static bool changeSettings = false;
    }
}

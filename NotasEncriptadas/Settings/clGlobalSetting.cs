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

        public static string filePath = "";//Direccion del archivo
        public static string encodedText = "";//Texto encritado del archivo
        
        public static bool openFile = false;//Archivo abierto .llave
        public static bool changeSettings = false;//Bandera, de cambios en las propiedades del archivo
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotasEncriptadas.Settings;

namespace NotasEncriptadas
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        public Int16 change;

        private void frmSettings_Load(object sender, EventArgs e)
        {
            clGlobalSetting.changeSettings = false;
        }
    }
}

namespace NotasEncriptadas
{
    partial class frmTextNotes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTextNotes));
            msMenu = new MenuStrip();
            tsmiFile = new ToolStripMenuItem();
            tsmiNew = new ToolStripMenuItem();
            tsmiOpen = new ToolStripMenuItem();
            tsmiSave = new ToolStripMenuItem();
            tsmiSaveClose = new ToolStripMenuItem();
            tssSeparator = new ToolStripSeparator();
            tsmiClose = new ToolStripMenuItem();
            tsmiUtilities = new ToolStripMenuItem();
            tsmiPassword = new ToolStripMenuItem();
            tsmiNIP = new ToolStripMenuItem();
            tsmiHelp = new ToolStripMenuItem();
            tsmiEmail = new ToolStripMenuItem();
            tsmiAbout = new ToolStripMenuItem();
            tssSeparator2 = new ToolStripSeparator();
            tsmiDonations = new ToolStripMenuItem();
            txtEncryptText = new TextBox();
            msMenu.SuspendLayout();
            SuspendLayout();
            // 
            // msMenu
            // 
            msMenu.Items.AddRange(new ToolStripItem[] { tsmiFile, tsmiUtilities, tsmiHelp });
            msMenu.Location = new Point(0, 0);
            msMenu.Name = "msMenu";
            msMenu.Size = new Size(479, 24);
            msMenu.TabIndex = 0;
            msMenu.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            tsmiFile.DropDownItems.AddRange(new ToolStripItem[] { tsmiNew, tsmiOpen, tsmiSave, tsmiSaveClose, tssSeparator, tsmiClose });
            tsmiFile.Name = "tsmiFile";
            tsmiFile.Size = new Size(60, 20);
            tsmiFile.Text = "Archivo";
            // 
            // tsmiNew
            // 
            tsmiNew.Name = "tsmiNew";
            tsmiNew.Size = new Size(160, 22);
            tsmiNew.Text = "&Nuevo";
            tsmiNew.Click += tsmiNew_Click;
            // 
            // tsmiOpen
            // 
            tsmiOpen.Name = "tsmiOpen";
            tsmiOpen.Size = new Size(160, 22);
            tsmiOpen.Text = "&Abrir";
            tsmiOpen.Click += tsmiOpen_Click;
            // 
            // tsmiSave
            // 
            tsmiSave.Name = "tsmiSave";
            tsmiSave.Size = new Size(160, 22);
            tsmiSave.Text = "&Guardar";
            tsmiSave.Click += tsmiSave_Click;
            // 
            // tsmiSaveClose
            // 
            tsmiSaveClose.Name = "tsmiSaveClose";
            tsmiSaveClose.Size = new Size(160, 22);
            tsmiSaveClose.Text = "G&uardar y Cerrar";
            tsmiSaveClose.Click += tsmiSaveClose_Click;
            // 
            // tssSeparator
            // 
            tssSeparator.Name = "tssSeparator";
            tssSeparator.Size = new Size(157, 6);
            // 
            // tsmiClose
            // 
            tsmiClose.Name = "tsmiClose";
            tsmiClose.Size = new Size(160, 22);
            tsmiClose.Text = "&Cerrar";
            tsmiClose.Click += tsmiClose_Click;
            // 
            // tsmiUtilities
            // 
            tsmiUtilities.DropDownItems.AddRange(new ToolStripItem[] { tsmiPassword, tsmiNIP });
            tsmiUtilities.Name = "tsmiUtilities";
            tsmiUtilities.Size = new Size(71, 20);
            tsmiUtilities.Text = "Utilidades";
            // 
            // tsmiPassword
            // 
            tsmiPassword.Name = "tsmiPassword";
            tsmiPassword.Size = new Size(182, 22);
            tsmiPassword.Text = "&Cambiar Contraseña";
            tsmiPassword.Click += tsmiPassword_Click;
            // 
            // tsmiNIP
            // 
            tsmiNIP.Name = "tsmiNIP";
            tsmiNIP.Size = new Size(182, 22);
            tsmiNIP.Text = "Cambiar &NIP";
            tsmiNIP.Click += tsmiNIP_Click;
            // 
            // tsmiHelp
            // 
            tsmiHelp.DropDownItems.AddRange(new ToolStripItem[] { tsmiEmail, tsmiAbout, tssSeparator2, tsmiDonations });
            tsmiHelp.Name = "tsmiHelp";
            tsmiHelp.Size = new Size(53, 20);
            tsmiHelp.Text = "Ayuda";
            // 
            // tsmiEmail
            // 
            tsmiEmail.Name = "tsmiEmail";
            tsmiEmail.Size = new Size(194, 22);
            tsmiEmail.Text = "&Enviar correo de ayuda";
            // 
            // tsmiAbout
            // 
            tsmiAbout.Name = "tsmiAbout";
            tsmiAbout.Size = new Size(194, 22);
            tsmiAbout.Text = "&Acerca de";
            // 
            // tssSeparator2
            // 
            tssSeparator2.Name = "tssSeparator2";
            tssSeparator2.Size = new Size(191, 6);
            // 
            // tsmiDonations
            // 
            tsmiDonations.Name = "tsmiDonations";
            tsmiDonations.Size = new Size(194, 22);
            tsmiDonations.Text = "&Donaciones";
            // 
            // txtEncryptText
            // 
            txtEncryptText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtEncryptText.Location = new Point(12, 27);
            txtEncryptText.Multiline = true;
            txtEncryptText.Name = "txtEncryptText";
            txtEncryptText.ScrollBars = ScrollBars.Vertical;
            txtEncryptText.Size = new Size(455, 322);
            txtEncryptText.TabIndex = 1;
            // 
            // frmTextNotes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 361);
            Controls.Add(txtEncryptText);
            Controls.Add(msMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msMenu;
            Name = "frmTextNotes";
            Text = "Encriptar nota";
            FormClosing += frmTextNotes_FormClosing;
            FormClosed += frmTextNotes_FormClosed;
            Load += frmTextNotes_Load;
            msMenu.ResumeLayout(false);
            msMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip msMenu;
        private ToolStripMenuItem tsmiFile;
        private ToolStripMenuItem tsmiNew;
        private ToolStripMenuItem tsmiOpen;
        private ToolStripMenuItem tsmiSave;
        private ToolStripMenuItem tsmiSaveClose;
        private ToolStripSeparator tssSeparator;
        private ToolStripMenuItem tsmiClose;
        private ToolStripMenuItem tsmiUtilities;
        private ToolStripMenuItem tsmiPassword;
        private ToolStripMenuItem tsmiNIP;
        private ToolStripMenuItem tsmiHelp;
        private ToolStripMenuItem tsmiEmail;
        private ToolStripMenuItem tsmiAbout;
        private ToolStripSeparator tssSeparator2;
        private ToolStripMenuItem tsmiDonations;
        private TextBox txtEncryptText;
    }
}
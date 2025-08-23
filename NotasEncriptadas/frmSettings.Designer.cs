namespace NotasEncriptadas
{
    partial class frmSettings
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnShowPassword = new Button();
            lblPIN = new Label();
            txtPIN = new TextBox();
            btnShowPIN = new Button();
            btnOk = new Button();
            ttMessage = new ToolTip(components);
            SuspendLayout();
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 9);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(67, 15);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(12, 27);
            txtPassword.MaxLength = 50;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(166, 23);
            txtPassword.TabIndex = 1;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // btnShowPassword
            // 
            btnShowPassword.BackgroundImage = Properties.Resources.ojo2;
            btnShowPassword.BackgroundImageLayout = ImageLayout.Zoom;
            btnShowPassword.Location = new Point(184, 27);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(25, 23);
            btnShowPassword.TabIndex = 2;
            btnShowPassword.UseVisualStyleBackColor = true;
            btnShowPassword.Click += btnShowPassword_Click;
            // 
            // lblPIN
            // 
            lblPIN.AutoSize = true;
            lblPIN.Location = new Point(12, 63);
            lblPIN.Name = "lblPIN";
            lblPIN.Size = new Size(26, 15);
            lblPIN.TabIndex = 3;
            lblPIN.Text = "PIN";
            // 
            // txtPIN
            // 
            txtPIN.Location = new Point(12, 81);
            txtPIN.MaxLength = 12;
            txtPIN.Name = "txtPIN";
            txtPIN.PasswordChar = '-';
            txtPIN.Size = new Size(166, 23);
            txtPIN.TabIndex = 4;
            txtPIN.KeyDown += txtPIN_KeyDown;
            // 
            // btnShowPIN
            // 
            btnShowPIN.BackgroundImage = Properties.Resources.ojo2;
            btnShowPIN.BackgroundImageLayout = ImageLayout.Zoom;
            btnShowPIN.Location = new Point(184, 81);
            btnShowPIN.Name = "btnShowPIN";
            btnShowPIN.Size = new Size(25, 23);
            btnShowPIN.TabIndex = 5;
            btnShowPIN.UseVisualStyleBackColor = true;
            btnShowPIN.Click += btnShowPIN_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(73, 118);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(73, 23);
            btnOk.TabIndex = 6;
            btnOk.Text = "&Aceptar";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(220, 153);
            Controls.Add(btnOk);
            Controls.Add(btnShowPIN);
            Controls.Add(txtPIN);
            Controls.Add(lblPIN);
            Controls.Add(btnShowPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(236, 192);
            MinimizeBox = false;
            MinimumSize = new Size(236, 192);
            Name = "frmSettings";
            Text = "Cambios";
            Load += frmSettings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnShowPassword;
        private Label lblPIN;
        private TextBox txtPIN;
        private Button btnShowPIN;
        private Button btnOk;
        private ToolTip ttMessage;
    }
}
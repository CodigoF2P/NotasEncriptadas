namespace NotasEncriptadas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnShowPassword = new Button();
            lblPIN = new Label();
            txtPIN = new TextBox();
            btnPIN = new Button();
            btnNew = new Button();
            btnOpen = new Button();
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
            txtPassword.Location = new Point(12, 27);
            txtPassword.MaxLength = 50;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(142, 23);
            txtPassword.TabIndex = 1;
            // 
            // btnShowPassword
            // 
            btnShowPassword.BackgroundImage = Properties.Resources.ojo2;
            btnShowPassword.BackgroundImageLayout = ImageLayout.Zoom;
            btnShowPassword.Location = new Point(160, 27);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(25, 23);
            btnShowPassword.TabIndex = 2;
            btnShowPassword.UseVisualStyleBackColor = true;
            btnShowPassword.Click += btnShowPassword_Click;
            // 
            // lblPIN
            // 
            lblPIN.AutoSize = true;
            lblPIN.Location = new Point(12, 53);
            lblPIN.Name = "lblPIN";
            lblPIN.Size = new Size(26, 15);
            lblPIN.TabIndex = 3;
            lblPIN.Text = "PIN";
            // 
            // txtPIN
            // 
            txtPIN.Location = new Point(12, 71);
            txtPIN.MaxLength = 12;
            txtPIN.Name = "txtPIN";
            txtPIN.PasswordChar = '*';
            txtPIN.Size = new Size(142, 23);
            txtPIN.TabIndex = 4;
            // 
            // btnPIN
            // 
            btnPIN.BackgroundImage = Properties.Resources.ojo2;
            btnPIN.BackgroundImageLayout = ImageLayout.Zoom;
            btnPIN.Location = new Point(160, 71);
            btnPIN.Name = "btnPIN";
            btnPIN.Size = new Size(25, 23);
            btnPIN.TabIndex = 5;
            btnPIN.UseVisualStyleBackColor = true;
            btnPIN.Click += btnPIN_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(12, 100);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 23);
            btnNew.TabIndex = 6;
            btnNew.Text = "&Nuevo";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(110, 100);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(75, 23);
            btnOpen.TabIndex = 7;
            btnOpen.Text = "&Abrir";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(196, 134);
            Controls.Add(btnOpen);
            Controls.Add(btnNew);
            Controls.Add(btnPIN);
            Controls.Add(txtPIN);
            Controls.Add(lblPIN);
            Controls.Add(btnShowPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(212, 173);
            MinimizeBox = false;
            MinimumSize = new Size(212, 173);
            Name = "Form1";
            Text = "Entrar";
            HelpButtonClicked += Form1_HelpButtonClicked;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnShowPassword;
        private Label lblPIN;
        private TextBox txtPIN;
        private Button btnPIN;
        private Button btnNew;
        private Button btnOpen;
    }
}
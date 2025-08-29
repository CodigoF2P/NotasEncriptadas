namespace NotasEncriptadas
{
    partial class frmEMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEMail));
            lblEMail = new Label();
            txtEMail = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblBody = new Label();
            txtBody = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // lblEMail
            // 
            lblEMail.AutoSize = true;
            lblEMail.Location = new Point(12, 15);
            lblEMail.Name = "lblEMail";
            lblEMail.Size = new Size(193, 15);
            lblEMail.TabIndex = 0;
            lblEMail.Text = "Escribe tu correo para seguimiento:";
            // 
            // txtEMail
            // 
            txtEMail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEMail.Location = new Point(211, 12);
            txtEMail.Name = "txtEMail";
            txtEMail.Size = new Size(277, 23);
            txtEMail.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 44);
            lblName.Name = "lblName";
            lblName.Size = new Size(108, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Escribe tu Nombre:";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(211, 41);
            txtName.Name = "txtName";
            txtName.Size = new Size(277, 23);
            txtName.TabIndex = 3;
            // 
            // lblBody
            // 
            lblBody.AutoSize = true;
            lblBody.Location = new Point(12, 67);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(326, 15);
            lblBody.TabIndex = 4;
            lblBody.Text = "Describe el error en la aplicacion o sugerencias para mejoras:";
            // 
            // txtBody
            // 
            txtBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBody.Location = new Point(12, 85);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.Size = new Size(476, 111);
            txtBody.TabIndex = 5;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Bottom;
            btnSend.Location = new Point(213, 202);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 6;
            btnSend.Text = "Enviar";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // frmEMail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 237);
            Controls.Add(btnSend);
            Controls.Add(txtBody);
            Controls.Add(lblBody);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(txtEMail);
            Controls.Add(lblEMail);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(516, 276);
            Name = "frmEMail";
            Text = "Enviar correo electonico";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEMail;
        private TextBox txtEMail;
        private Label lblName;
        private TextBox txtName;
        private Label lblBody;
        private TextBox txtBody;
        private Button btnSend;
    }
}
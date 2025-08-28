namespace NotasEncriptadas
{
    partial class frmDonation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonation));
            lblDonation = new Label();
            SuspendLayout();
            // 
            // lblDonation
            // 
            lblDonation.AutoSize = true;
            lblDonation.Location = new Point(12, 9);
            lblDonation.Name = "lblDonation";
            lblDonation.Size = new Size(257, 75);
            lblDonation.TabIndex = 0;
            lblDonation.Text = resources.GetString("lblDonation.Text");
            lblDonation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmDonation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(281, 98);
            Controls.Add(lblDonation);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(297, 137);
            MinimizeBox = false;
            MinimumSize = new Size(297, 137);
            Name = "frmDonation";
            Text = "Donaciones";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDonation;
    }
}
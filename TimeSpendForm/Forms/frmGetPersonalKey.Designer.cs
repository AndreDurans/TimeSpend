namespace TimeSpendForm.Forms
{
    partial class frmGetPersonalKey
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
            this.personalUserKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // personalUserKey
            // 
            this.personalUserKey.Location = new System.Drawing.Point(212, 80);
            this.personalUserKey.Name = "personalUserKey";
            this.personalUserKey.Size = new System.Drawing.Size(376, 27);
            this.personalUserKey.TabIndex = 0;
            this.personalUserKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.personalUserKey_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Personal User Key:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Continuar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmGetPersonalKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 271);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.personalUserKey);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGetPersonalKey";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGetPersonalKey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox personalUserKey;
        private Label label1;
        private Button button1;
    }
}
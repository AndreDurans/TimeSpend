namespace TimeSpendForm.Forms
{
    partial class frmMain
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
            this.lblProjeto = new System.Windows.Forms.Label();
            this.ddProject = new System.Windows.Forms.ComboBox();
            this.lblCard = new System.Windows.Forms.Label();
            this.ddCard = new System.Windows.Forms.ComboBox();
            this.lblQtdHoras = new System.Windows.Forms.Label();
            this.qtdHora = new System.Windows.Forms.NumericUpDown();
            this.qtdMinuto = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.ddDescription = new System.Windows.Forms.ComboBox();
            this.tbDescricao = new System.Windows.Forms.TextBox();
            this.lbDescricaoNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.qtdHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtdMinuto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProjeto
            // 
            this.lblProjeto.AutoSize = true;
            this.lblProjeto.Location = new System.Drawing.Point(51, 23);
            this.lblProjeto.Name = "lblProjeto";
            this.lblProjeto.Size = new System.Drawing.Size(60, 20);
            this.lblProjeto.TabIndex = 0;
            this.lblProjeto.Text = "Projeto:";
            // 
            // ddProject
            // 
            this.ddProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddProject.FormattingEnabled = true;
            this.ddProject.Location = new System.Drawing.Point(124, 20);
            this.ddProject.Name = "ddProject";
            this.ddProject.Size = new System.Drawing.Size(264, 28);
            this.ddProject.TabIndex = 1;
            this.ddProject.SelectedIndexChanged += new System.EventHandler(this.ddProject_SelectedIndexChanged);
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Location = new System.Drawing.Point(68, 61);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(43, 20);
            this.lblCard.TabIndex = 2;
            this.lblCard.Text = "Card:";
            // 
            // ddCard
            // 
            this.ddCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddCard.FormattingEnabled = true;
            this.ddCard.Location = new System.Drawing.Point(124, 56);
            this.ddCard.Name = "ddCard";
            this.ddCard.Size = new System.Drawing.Size(795, 28);
            this.ddCard.TabIndex = 3;
            // 
            // lblQtdHoras
            // 
            this.lblQtdHoras.AutoSize = true;
            this.lblQtdHoras.Location = new System.Drawing.Point(34, 143);
            this.lblQtdHoras.Name = "lblQtdHoras";
            this.lblQtdHoras.Size = new System.Drawing.Size(77, 20);
            this.lblQtdHoras.TabIndex = 4;
            this.lblQtdHoras.Text = "Qtd. Hora:";
            // 
            // qtdHora
            // 
            this.qtdHora.Location = new System.Drawing.Point(125, 136);
            this.qtdHora.Name = "qtdHora";
            this.qtdHora.Size = new System.Drawing.Size(64, 27);
            this.qtdHora.TabIndex = 5;
            // 
            // qtdMinuto
            // 
            this.qtdMinuto.Location = new System.Drawing.Point(324, 136);
            this.qtdMinuto.Name = "qtdMinuto";
            this.qtdMinuto.Size = new System.Drawing.Size(64, 27);
            this.qtdMinuto.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Qtd. Minuto:";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(420, 228);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(94, 29);
            this.btnEnviar.TabIndex = 8;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(7, 99);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(104, 20);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Apontamento:";
            // 
            // ddDescription
            // 
            this.ddDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddDescription.FormattingEnabled = true;
            this.ddDescription.Location = new System.Drawing.Point(125, 96);
            this.ddDescription.Name = "ddDescription";
            this.ddDescription.Size = new System.Drawing.Size(263, 28);
            this.ddDescription.TabIndex = 10;
            this.ddDescription.SelectedIndexChanged += new System.EventHandler(this.ddDescription_SelectedIndexChanged);
            // 
            // tbDescricao
            // 
            this.tbDescricao.Location = new System.Drawing.Point(479, 97);
            this.tbDescricao.Name = "tbDescricao";
            this.tbDescricao.Size = new System.Drawing.Size(440, 27);
            this.tbDescricao.TabIndex = 11;
            // 
            // lbDescricaoNote
            // 
            this.lbDescricaoNote.AutoSize = true;
            this.lbDescricaoNote.Location = new System.Drawing.Point(396, 99);
            this.lbDescricaoNote.Name = "lbDescricaoNote";
            this.lbDescricaoNote.Size = new System.Drawing.Size(77, 20);
            this.lbDescricaoNote.TabIndex = 12;
            this.lbDescricaoNote.Text = "Descrição:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 309);
            this.Controls.Add(this.lbDescricaoNote);
            this.Controls.Add(this.tbDescricao);
            this.Controls.Add(this.ddDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.qtdMinuto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qtdHora);
            this.Controls.Add(this.lblQtdHoras);
            this.Controls.Add(this.ddCard);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.ddProject);
            this.Controls.Add(this.lblProjeto);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qtdHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtdMinuto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblProjeto;
        private ComboBox ddProject;
        private Label lblCard;
        private ComboBox ddCard;
        private Label lblQtdHoras;
        private NumericUpDown qtdHora;
        private NumericUpDown qtdMinuto;
        private Label label1;
        private Button btnEnviar;
        private Label lblDescription;
        private ComboBox ddDescription;
        private TextBox tbDescricao;
        private Label lbDescricaoNote;
    }
}
namespace LojaVeiculos
{
    partial class frmMenu
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
            this.pnMenu = new System.Windows.Forms.Panel();
            this.lblConsulta = new System.Windows.Forms.Label();
            this.lblVeiculos = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnConteudo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnMenu.SuspendLayout();
            this.pnConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(15)))));
            this.pnMenu.Controls.Add(this.lblConsulta);
            this.pnMenu.Controls.Add(this.lblVeiculos);
            this.pnMenu.Controls.Add(this.lblCliente);
            this.pnMenu.Controls.Add(this.lblInicio);
            this.pnMenu.Controls.Add(this.btnSair);
            this.pnMenu.Controls.Add(this.flowLayoutPanel1);
            this.pnMenu.Location = new System.Drawing.Point(0, 0);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(164, 500);
            this.pnMenu.TabIndex = 0;
            // 
            // lblConsulta
            // 
            this.lblConsulta.AutoSize = true;
            this.lblConsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblConsulta.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsulta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblConsulta.Location = new System.Drawing.Point(41, 218);
            this.lblConsulta.Name = "lblConsulta";
            this.lblConsulta.Size = new System.Drawing.Size(79, 21);
            this.lblConsulta.TabIndex = 9;
            this.lblConsulta.Text = "Consulta";
            this.lblConsulta.Click += new System.EventHandler(this.lblConsulta_Click);
            // 
            // lblVeiculos
            // 
            this.lblVeiculos.AutoSize = true;
            this.lblVeiculos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVeiculos.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVeiculos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblVeiculos.Location = new System.Drawing.Point(41, 172);
            this.lblVeiculos.Name = "lblVeiculos";
            this.lblVeiculos.Size = new System.Drawing.Size(76, 21);
            this.lblVeiculos.TabIndex = 8;
            this.lblVeiculos.Text = "Veículos";
            this.lblVeiculos.Click += new System.EventHandler(this.lblVeiculos_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCliente.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblCliente.Location = new System.Drawing.Point(47, 122);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(65, 21);
            this.lblCliente.TabIndex = 7;
            this.lblCliente.Text = "Cliente";
            this.lblCliente.Click += new System.EventHandler(this.lblCliente_Click);
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInicio.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblInicio.Location = new System.Drawing.Point(52, 76);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(53, 21);
            this.lblInicio.TabIndex = 6;
            this.lblInicio.Text = "Início";
            this.lblInicio.Click += new System.EventHandler(this.lblInicio_Click);
            // 
            // btnSair
            // 
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnSair.Location = new System.Drawing.Point(45, 404);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 42);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(165, 8);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(634, 438);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // pnConteudo
            // 
            this.pnConteudo.Controls.Add(this.pictureBox1);
            this.pnConteudo.Location = new System.Drawing.Point(165, 0);
            this.pnConteudo.Name = "pnConteudo";
            this.pnConteudo.Size = new System.Drawing.Size(634, 500);
            this.pnConteudo.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LojaVeiculos.Properties.Resources.teste;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(634, 499);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pnConteudo);
            this.Controls.Add(this.pnMenu);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMenu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.pnMenu.ResumeLayout(false);
            this.pnMenu.PerformLayout();
            this.pnConteudo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblConsulta;
        private System.Windows.Forms.Label lblVeiculos;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Panel pnConteudo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
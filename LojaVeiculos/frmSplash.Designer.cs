namespace LojaVeiculos
{
    partial class frmSplash
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pgSplash = new System.Windows.Forms.ProgressBar();
            this.pbSplash = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pgSplash
            // 
            this.pgSplash.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pgSplash.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pgSplash.Location = new System.Drawing.Point(12, 253);
            this.pgSplash.Name = "pgSplash";
            this.pgSplash.Size = new System.Drawing.Size(633, 35);
            this.pgSplash.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgSplash.TabIndex = 3;
            // 
            // pbSplash
            // 
            this.pbSplash.BackgroundImage = global::LojaVeiculos.Properties.Resources.logoalt;
            this.pbSplash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSplash.Location = new System.Drawing.Point(117, -43);
            this.pbSplash.Name = "pbSplash";
            this.pbSplash.Size = new System.Drawing.Size(414, 340);
            this.pbSplash.TabIndex = 4;
            this.pbSplash.TabStop = false;
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(658, 300);
            this.Controls.Add(this.pgSplash);
            this.Controls.Add(this.pbSplash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            this.Load += new System.EventHandler(this.frmSplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSplash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar pgSplash;
        private System.Windows.Forms.PictureBox pbSplash;
    }
}
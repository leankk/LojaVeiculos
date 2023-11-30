using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LojaVeiculos
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        //método para contagem e progresso da ProgressBar
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pgSplash.Value < 100)
            {
                pgSplash.Value += 5;
            }
            else
            {
                timer1.Enabled = false;
                this.Visible = false;
                frmLogin objLogin = new frmLogin();
                objLogin.ShowDialog();
            }

        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            pgSplash.Style = ProgressBarStyle.Continuous;
            pgSplash.ForeColor = Color.FromArgb(100, 0, 25);
        }
    }
}

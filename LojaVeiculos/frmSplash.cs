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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pgSplash.Value < 100)
            {
                pgSplash.Value += 20;
            }
            else
            {
                timer1.Enabled = false;
                this.Visible = false;
                frmMenu objmenu = new frmMenu();
                objmenu.ShowDialog();
            }

        }

        public void ProgressBarLinearGradiente(PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(
            new Point(0, 10),
            new Point(200, 10),
            Color.FromArgb(100, 0, 15, 0),   // Opaque red
            Color.FromArgb(80, 0, 15, 255));  // Opaque blue

            Pen pen = new Pen(linGrBrush);

            e.Graphics.DrawLine(pen, 0, 10, 200, 10);
            e.Graphics.FillEllipse(linGrBrush, 0, 30, 200, 100);
            e.Graphics.FillRectangle(linGrBrush, 0, 155, 500, 30);
        }
    }
}

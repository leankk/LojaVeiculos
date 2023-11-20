using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaVeiculos
{
    public partial class frmVeiculos : Form
    {
        public frmVeiculos()
        {
            InitializeComponent();
        }

        Conexao con = new Conexao();
        formDAO dao = new formDAO();

        private void frmVeiculos_Load(object sender, EventArgs e)
        {
            pbLine.BackColor = Color.White;
        }

        private void pbLine_Paint(object sender, PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;

            // Draw a line in the PictureBox.
            g.DrawLine(Pens.White, pbLine.Left, pbLine.Top,
                pbLine.Right, pbLine.Bottom);
        }
         private void ValidateFields()
        {
            if (txtModel.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Modelo!", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModel.Focus();
            }
            else if (txtCor.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Cor!", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCor.Focus();
            }
            else if (txtFab.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Fabricante!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFab.Focus();
            }
            else if (txtPlaca.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Placa!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPlaca.Focus();
            }
            else
            {
                try
                {
                    dao.InsertCars();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

    }
}

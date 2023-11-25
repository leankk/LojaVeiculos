using MySql.Data.MySqlClient;
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
            Graphics g = e.Graphics;

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
                    InsertCars();
                    ClearFields();
                    txtMarca.Focus();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Não foi possível cadastrar o cliente.\nMotivo do erro: " + ex, "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Disconnect();
                    ClearFields();
                    txtMarca.Focus();
                }
            }
         }

        public void InsertCars()
        {
            string strCarsSql = $"INSERT INTO TBVEICULOS (NMMODELO, NMFABRICACAO, NOPLACA, NMMARCA, VLPRECO, DSCOR, DSDESCRICAO)" +
                $" AND VALUES ('{txtModel.Text}', '{txtFab.Text}', '{txtPlaca.Text}', '{txtMarca.Text}', '{txtPreco.Text}', '{txtCor.Text}', '{txtDesc.Text}');";

            MySqlCommand cmdCars = new MySqlCommand(strCarsSql, con.Connect());
            cmdCars.ExecuteNonQuery();

            MessageBox.Show("Dados cadastrados com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Disconnect();
        }

        private void ClearFields()
        {
            txtMarca.Clear();
            txtModel.Clear();
            txtPlaca.Clear();
            txtFab.Clear();
            txtDesc.Clear();
            txtCor.Clear();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            ValidateFields();
        }
    }
}

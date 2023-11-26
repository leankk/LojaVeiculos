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

        string id, tipo, fab, placa, modelo, preco, cor, desc, data;

        Conexao con = new Conexao();

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

        private void txtConsult_TextChanged(object sender, EventArgs e)
        {
            try
            { 
                fab = txtConsult.Text;

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = $"SELECT * FROM TBVEICULO WHERE NMFABRICANTE = '{fab}'";

                cmd.Connection = con.Connect();
                MySqlDataAdapter objVei = new MySqlDataAdapter();
                DataTable dbVei = new DataTable();

                objVei.SelectCommand = cmd;
                objVei.Fill(dbVei);
                dgvVeiculos.DataSource = dbVei;

                con.Disconnect();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocorreu um erro ao mostrar os dados.\nMotivo do erro: " + ex, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVeiculos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FillCells();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tipo = txtTipo.Text;
            fab = txtFab.Text;
            placa = txtPlaca.Text;
            modelo = txtModelo.Text;
            preco = txtPreco.Text;
            cor = txtCor.Text;
            desc = txtDesc.Text;
            data = dtFab.Text;
            id = txtIdVei.Text;

            if (ValidateFields())
            {
                DeleteCars();
                ClearFields();

                txtModelo.Focus();
            }
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            tipo = txtTipo.Text;
            fab = txtFab.Text;
            placa = txtPlaca.Text;
            modelo = txtModelo.Text;
            preco = txtPreco.Text;
            cor = txtCor.Text;
            desc = txtDesc.Text;
            data = dtFab.Text;
            id = txtIdVei.Text;

            if (ValidateFields())
            {
                InsertCars();
                ClearFields();

                txtModelo.Focus();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            tipo = txtTipo.Text;
            fab = txtFab.Text;
            placa = txtPlaca.Text;
            modelo = txtModelo.Text;
            preco = txtPreco.Text;
            cor = txtCor.Text;
            desc = txtDesc.Text;
            data = dtFab.Text;
            id = txtIdVei.Text;

            if(ValidateFields())
            {
                UpdateCars();
                ClearFields();

                txtModelo.Focus();
            } 
        }

        private bool ValidateFields()
         {
            if (txtTipo.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Modelo!", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTipo.Focus();
                return false;
            }
            else if (txtCor.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Cor!", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCor.Focus();
                return false;
            }
            else if (txtFab.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Fabricante!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFab.Focus();
                return false;
            }
            else if (txtPlaca.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Placa!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPlaca.Focus();
                return false;
            }
            else if (txtPreco.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Preço!", "Erro",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPreco.Focus();
                return false;
            }
            else if (dtFab.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Placa!", "Erro",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtFab.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ClearFields()
        {
            txtModelo.Clear();
            txtTipo.Clear();
            txtPlaca.Clear();
            txtFab.Clear();
            txtDesc.Clear();
            txtCor.Clear();
            txtPreco.Clear();
            dtFab.Clear();
            txtIdVei.Clear();
        }

        private void InsertCars()
        {
            try
            {
                string strCars = $"INSERT INTO TBVEICULO (NMFABRICANTE, DSTIPO, NMMODELO, DTFABRICACAO, NOPLACA, VLPRECO, DSCOR, DSDESCRICAO)" +
                $" VALUES ('{fab}', '{tipo}', '{modelo}', '{data}', '{placa}', '{preco}', '{cor}', '{desc}');";

                MySqlCommand cmdCars = new MySqlCommand(strCars, con.Connect());

                cmdCars.ExecuteNonQuery();

                MessageBox.Show("Dados cadastrados com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível cadastrar os dados.\nMotivo do erro: " + ex, "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Disconnect();
                ClearFields();
                txtModelo.Focus();
            }
            
        }

        private void UpdateCars()
        {
            try
            {
                string strCars = $"UPDATE TBVEICULO" +
                $" SET NMFABRICANTE = '{fab}', DSTIPO = '{tipo}', NMMODELO = '{modelo}', DTFABRICACAO = '{data}', NOPLACA = '{placa}', VLPRECO = '{preco}', DSCOR = '{cor}', DSDESCRICAO = '{desc}'" +
                $"WHERE CDVEICULO = '{id}';";

                MySqlCommand cmdCars = new MySqlCommand(strCars, con.Connect());

                cmdCars.ExecuteNonQuery();

                MessageBox.Show("Dados atualizados com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível atualizar os dados.\nMotivo do erro: " + ex, "Erro",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Disconnect();
                ClearFields();
                txtModelo.Focus();
            }
        }

        private void DeleteCars()
        {
            try
            {
                string strCars = $"DELETE FROM TBVEICULO WHERE CDVEICULO = '{id}';";

                MySqlCommand cmdCars = new MySqlCommand(strCars, con.Connect());

                cmdCars.ExecuteNonQuery();

                MessageBox.Show("Dados deletados com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível deletar os dados.\nMotivo do erro: " + ex, "Erro",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Disconnect();
                ClearFields();
                txtModelo.Focus();
            }
        }

        private void FillCells()
        {
            try
            {
                txtIdVei.Text = dgvVeiculos.SelectedRows[0].Cells[0].Value.ToString();
                txtFab.Text = dgvVeiculos.SelectedRows[0].Cells[1].Value.ToString();
                txtTipo.Text = dgvVeiculos.SelectedRows[0].Cells[2].Value.ToString();
                txtModelo.Text = dgvVeiculos.SelectedRows[0].Cells[3].Value.ToString();
                dtFab.Text = dgvVeiculos.SelectedRows[0].Cells[4].Value.ToString();
                txtPlaca.Text = dgvVeiculos.SelectedRows[0].Cells[5].Value.ToString();
                txtPreco.Text = dgvVeiculos.SelectedRows[0].Cells[6].Value.ToString();
                txtCor.Text = dgvVeiculos.SelectedRows[0].Cells[7].Value.ToString();
                txtDesc.Text = dgvVeiculos.SelectedRows[0].Cells[8].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível selecionar a informação requerida.\nMotivo do erro: " + ex, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvVeiculos.DataSource = null;
            }
        }
    }
}

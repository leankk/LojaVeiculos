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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        string id, nome, senha;

        Conexao con = new Conexao();

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            pbLine.BackColor = Color.White;
            txtIdUsu.Enabled = false;
            //dgvUsers.BackgroundColor = Color.FromArgb(100,0,15);
            //dgvUsers.DefaultCellStyle.BackColor = Color.FromArgb(25, 25, 25);
            dgvUsers.Visible = false;
        }

        private void pbLine_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawLine(Pens.White, pbLine.Left, pbLine.Top,
                pbLine.Right, pbLine.Bottom);
        }

        private void txtPesq_TextChanged(object sender, EventArgs e)
        {
            try
            {
                nome = txtConsult.Text;

                dgvUsers.Visible = true;

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = $"SELECT * FROM TBLOGIN WHERE NMUSUARIO = '{nome}'";

                cmd.Connection = con.Connect();
                MySqlDataAdapter objUser = new MySqlDataAdapter();
                DataTable dbUser = new DataTable();

                objUser.SelectCommand = cmd;
                objUser.Fill(dbUser);
                dgvUsers.DataSource = dbUser;

                con.Disconnect();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocorreu um erro ao mostrar os dados.\nMotivo do erro: " + ex, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvUsers.DataSource = null;
            }
        }

        private void dgvUsers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FillCells();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                id = txtIdUsu.Text;
                nome = txtNome.Text;
                senha = txtSenha.Text;

                if (MessageBox.Show("Deseja realizar o cadastro desses dados?", "Cadastrar Dados",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    InsertUser();
                    ClearFields();

                    txtNome.Focus();
                }
            }
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            id = txtIdUsu.Text;
            nome = txtNome.Text;
            senha = txtSenha.Text;

            if (ValidateFields())
            {
                if (MessageBox.Show("Deseja realizar a alteração desses dados?", "Alterar Dados",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UpdateUser();
                    ClearFields();

                    txtNome.Focus();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            id = txtIdUsu.Text;
            nome = txtNome.Text;
            senha = txtSenha.Text;

            if (ValidateFields())
            {
                if (MessageBox.Show("Deseja realizar a exclusão desses dados?", "Excluir Dados",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteUser();
                    ClearFields();

                    txtNome.Focus();
                }
            }
        }

        private void chkPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPwd.Checked)
            {
                txtSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
            }
        }

        private bool ValidateFields()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Obrigatório preencher o campo Nome!", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;
            }
            else if (txtSenha.Text == "")
            {
                MessageBox.Show("Obrigatório preencher o campo Senha!", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ClearFields()
        {
            txtIdUsu.Clear();
            txtNome.Clear();
            txtSenha.Clear();
        }

        private void InsertUser()
        {
            try
            {
                string strUser = $"INSERT INTO TBLOGIN (NMUSUARIO, DSSENHA) VALUES ('{nome}', '{senha}');";

                MySqlCommand cmdUser = new MySqlCommand(strUser, con.Connect());

                cmdUser.ExecuteNonQuery();

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
                txtNome.Focus();
            }
        }

        private void UpdateUser()
        {
            try
            {
                string strUser = $"UPDATE TBLOGIN SET NMUSUARIO = '{nome}', DSSENHA = '{senha}' WHERE CDLOGIN = '{id}';";

                MySqlCommand cmdUser = new MySqlCommand(strUser, con.Connect());

                cmdUser.ExecuteNonQuery();

                MessageBox.Show("Dados atualizados com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Disconnect();
                txtNome.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível atualizar os dados.\nMotivo do erro: " + ex, "Erro",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Disconnect();
                ClearFields();
                txtNome.Focus();
            }
        }

        private void DeleteUser()
        {
            try
            {
                string strUser = $"DELETE FROM TBLOGIN WHERE CDLOGIN = '{id}';";

                MySqlCommand cmdUser = new MySqlCommand(strUser, con.Connect());

                cmdUser.ExecuteNonQuery();

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
                txtNome.Focus();
            }
        }

        private void FillCells()
        {
            try
            {
                txtIdUsu.Text = dgvUsers.SelectedRows[0].Cells[0].Value.ToString();
                txtNome.Text = dgvUsers.SelectedRows[0].Cells[1].Value.ToString();
                txtSenha.Text = dgvUsers.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível selecionar a informação requerida.\nMotivo do erro: " + ex, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvUsers.DataSource = null;
            }
        }
    }
}
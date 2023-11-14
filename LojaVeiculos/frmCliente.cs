using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace LojaVeiculos
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        Conexao con = new Conexao();

        private void ValidateFields()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Nome!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
            }
            else if (txtSobreNome.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Sobrenome!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSobreNome.Focus();
            }
            else if (dtNasc.Text == "")
            {
                MessageBox.Show("Digite uma data", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNasc.Focus();
            }
            else if (txtLogra.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Logradouro!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogra.Focus();
            }
            else if (nmNoResi.Value < 0)
            {
                MessageBox.Show("Use apenas números positivos!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                nmNoResi.Focus();
            }
            else if (txtBairro.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Bairro!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBairro.Focus();
            }
            else if (txtCidade.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Cidade!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCidade.Focus();
            }
            else if (lbEstados.SelectedIndex == -1)
            {
                MessageBox.Show("Obrigatório selecionar um estado da lista!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbEstados.Focus();
            }
            else
            {
                try
                {
                    Convert.ToString(dtNasc.Text);

                    string strSql = "INSERT INTO TBCLIENTE (NM_CLI, SOBRENOME_CLI, DT_NASC) VALUES (@nome, @sobrenome, STR_TO_DATE(@datanasc, '%d %m %Y %T'));";
                    MySqlCommand cmd = new MySqlCommand(strSql, con.Connect());

                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = txtNome.Text;
                    cmd.Parameters.Add("@sobrenome", MySqlDbType.VarChar).Value = txtSobreNome.Text;
                    cmd.Parameters.Add("@datanasc", MySqlDbType.Date).Value = dtNasc.Text;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Dados cadastrados com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    txtNome.Focus();

                    con.Disconnect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível cadastrar o cliente.\nMotivo do erro: " + ex.Message);
                    con.Disconnect();
                    ClearFields();
                }
            }
        }

        private void ClearFields()
        {
            txtNome.Clear();
            txtSobreNome.Clear();
            dtNasc.Clear();
            txtLogra.Clear();
            nmNoResi.Value = 0;
            txtBairro.Clear();
            txtCidade.Clear();
            lbEstados.SelectedIndex = -1;
        }

        private void frmCliente_Load(object sender, EventArgs e)
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
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            ValidateFields();
        }
    }
}

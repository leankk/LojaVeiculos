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

        readonly Conexao con = new Conexao();

        string idcli, idend, nome, sobrenome, datanasc, logra, numlogra, uf, cidade, bairro, desc;


        private void btnCadastro_Click(object sender, EventArgs e)
        {
            idcli = txtIdCli.Text;
            idend = txtIdEnd.Text;
            nome = txtNome.Text;
            sobrenome = txtSobreNome.Text;
            datanasc = dtNasc.Text;
            logra = txtLogra.Text;
            numlogra = nmNoResi.Value.ToString();
            uf = lbEstados.SelectedItem.ToString();
            cidade = txtCidade.Text;
            bairro = txtBairro.Text;
            desc = txtDesc.Text;

            if (ValidateFields())
            {
                 InsertClient();
                 ClearFields();
                 txtNome.Focus();
            }

        }

        private bool ValidateFields()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Nome!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;

            }
            else if (txtSobreNome.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Sobrenome!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSobreNome.Focus();
                return false;
            }
            else if (dtNasc.Text == "")
            {
                MessageBox.Show("Digite uma data", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNasc.Focus();
                return false;
            }
            else if (!dtNasc.MaskCompleted)
            {
                MessageBox.Show("Obrigatório Preencher o campo Logradouro!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogra.Focus();
                return false;
            }
            else if (nmNoResi.Value < 0)
            {
                MessageBox.Show("Use apenas números positivos!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                nmNoResi.Focus();
                return false;
            }
            else if (txtBairro.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Bairro!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBairro.Focus();
                return false;
            }
            else if (txtCidade.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Cidade!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCidade.Focus();
                return false;
            }
            else if (lbEstados.SelectedIndex == -1)
            {
                MessageBox.Show("Obrigatório selecionar um estado da lista!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbEstados.Focus();
                return false;
            }
            else
            {
                return true;
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


        private void InsertClient()
        {
            try
            {
                string strCliSql = $"INSERT INTO TBCLIENTE (NMNOME, NMSOBRENOME, DTNASCIMENTO)" +
                    $" VALUES ('{nome}', '{sobrenome}', STR_TO_DATE('{datanasc}', '%d/%m/%Y %T'));";

                MySqlCommand cmdCli = new MySqlCommand(strCliSql, con.Connect());
                cmdCli.ExecuteNonQuery();

                MessageBox.Show("Dados cadastrados com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível cadastrar o cliente.\nMotivo do erro" + ex, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Disconnect();
            }
        }
    }
}

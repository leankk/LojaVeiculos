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
        formDAO dao = new formDAO();

        public string nome, sobrenome, datanasc;

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
                try
                {
                    dao.InsertClient();
                    ClearFields();
                    txtNome.Focus();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível cadastrar o cliente.\nMotivo do erro: " + ex.Message);
                    con.Disconnect();
                    ClearFields();
                    return false;
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
            Graphics g = e.Graphics;

            g.DrawLine(Pens.White, pbLine.Left, pbLine.Top,
                pbLine.Right, pbLine.Bottom);
        }
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
            txtNome.Text = nome;
            txtSobreNome.Text = sobrenome;
            dtNasc.Text = datanasc;
            }
            
        }
    }
}

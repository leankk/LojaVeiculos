using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
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

        private void frmCliente_Load(object sender, EventArgs e)
        {
            dgvClients.Visible = false;
            pbLine.BackColor = Color.White;
            txtIdCli.Enabled = false;
            txtIdEnd.Enabled = false;
            dgvClients.BackgroundColor = Color.FromArgb(25, 25, 25);
        }

        private void frmCliente_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawLine(Pens.White, pbLine.Left, pbLine.Top,
                pbLine.Right, pbLine.Bottom);
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                idcli = txtIdCli.Text;
                idend = txtIdEnd.Text;
                nome = txtNome.Text;
                sobrenome = txtSobreNome.Text;
                datanasc = txtdtNasc.Text;
                logra = txtLogra.Text;
                numlogra = txtNoResi.Text;
                uf = lbEstados.SelectedItem.ToString();
                cidade = txtCidade.Text;
                bairro = txtBairro.Text;
                desc = txtDesc.Text;

                if (MessageBox.Show("Deseja realizar o cadastro desses dados?", "Cadastrar Dados",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    InsertClient();
                    ClearFields();
                    txtNome.Focus();
                }
            }
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                idcli = txtIdCli.Text;
                idend = txtIdEnd.Text;
                nome = txtNome.Text;
                sobrenome = txtSobreNome.Text;
                datanasc = txtdtNasc.Text;
                logra = txtLogra.Text;
                numlogra = txtNoResi.Text;
                uf = lbEstados.SelectedItem.ToString();
                cidade = txtCidade.Text;
                bairro = txtBairro.Text;
                desc = txtDesc.Text;

                if (MessageBox.Show("Deseja realizar a alteração desses dados?", "Alterar Dados",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UpdateClient();
                    ClearFields();

                    txtNome.Focus();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                idcli = txtIdCli.Text;
                idend = txtIdEnd.Text;
                nome = txtNome.Text;
                sobrenome = txtSobreNome.Text;
                datanasc = txtdtNasc.Text;
                logra = txtLogra.Text;
                numlogra = txtNoResi.Text;
                uf = lbEstados.SelectedItem.ToString();
                cidade = txtCidade.Text;
                bairro = txtBairro.Text;
                desc = txtDesc.Text;
           
                if (MessageBox.Show("Deseja realizar a exclusão desses dados?", "Excluir Dados",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteClient();
                    ClearFields();

                    txtNome.Focus();
                }
            }
        }

        private void txtConsult_TextChanged(object sender, EventArgs e)
        {
            try
            {
                nome = txtConsult.Text;

                dgvClients.Visible = true;

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = $"SELECT * FROM TBCLIENTE" +
                    $" INNER JOIN TBENDERECOCLI" +
                    $" ON TBCLIENTE.CDCLI = TBENDERECOCLI.CDENDERECO" +
                    $" WHERE NMNOME = '{nome}';";

                cmd.Connection = con.Connect();
                MySqlDataAdapter objCli = new MySqlDataAdapter();
                DataTable dbCli = new DataTable();

                objCli.SelectCommand = cmd;
                objCli.Fill(dbCli);
                dgvClients.DataSource = dbCli;

                con.Disconnect();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocorreu um erro ao mostrar os dados.\nMotivo do erro: " + ex, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvClients.DataSource = null;
            }
        }

        private void dgvClients_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FillCells();
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
            else if (txtdtNasc.Text == "")
            {
                MessageBox.Show("Digite uma data", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdtNasc.Focus();
                return false;
            }
            else if (!txtdtNasc.MaskCompleted)
            {
                MessageBox.Show("Obrigatório Preencher o campo Data de Nascimento!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogra.Focus();
                return false;
            }
            else if (txtNoResi.Text == "")
            {
                MessageBox.Show("Obrigatório Preencher o campo Nº da Residência!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNoResi.Focus();
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
            txtIdCli.Clear();
            txtIdEnd.Clear();
            txtNome.Clear();
            txtSobreNome.Clear();
            txtdtNasc.Clear();
            txtLogra.Clear();
            txtNoResi.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            lbEstados.SelectedIndex = -1;
            txtDesc.Clear();
            txtConsult.Clear();
        }

        private void InsertClient()
        {
            try
            {
                string strCliSql = $"START TRANSACTION;" +
                    $" INSERT INTO TBENDERECOCLI (NMLOGRADOURO, NOLOGRADOURO, SGUF, NMCIDADE, NMBAIRRO, DSCOMPLEMENTO) " +
                    $" VALUES ('{logra}', '{numlogra}', '{uf}', '{cidade}', '{bairro}', '{desc}');" +
                    $" INSERT INTO TBCLIENTE (NMNOME, NMSOBRENOME, DTNASCIMENTO, CDENDERECO)" +
                    $" VALUES ('{nome}', '{sobrenome}', STR_TO_DATE('{datanasc}', '%d/%m/%Y %T'), LAST_INSERT_ID());" +
                    $"SET FOREIGN_KEY_CHECKS = 1;" +   
                    $"COMMIT;";

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

        private void UpdateClient()
        {
            try
            {
                string strCli = $"START TRANSACTION;" +
                    $" UPDATE TBENDERECOCLI" +
                    $" SET NMLOGRADOURO = '{logra}', NOLOGRADOURO = '{numlogra}', SGUF = '{uf}', NMCIDADE = '{cidade}', NMBAIRRO = '{bairro}', DSCOMPLEMENTO = '{desc}'" +
                    $" WHERE CDENDERECO = '{idend}';" +

                    $" UPDATE TBCLIENTE" +
                    $" SET NMNOME = '{nome}', NMSOBRENOME = '{sobrenome}', DTNASCIMENTO = STR_TO_DATE('{datanasc}', '%d/%m/%Y %T'), CDENDERECO = '{idend}'" +
                    $" WHERE CDCLI = '{idcli}';" +
                    "  SET FOREIGN_KEY_CHECKS = 1;" +
                    $" COMMIT;";

                MySqlCommand cmdCli = new MySqlCommand(strCli, con.Connect());

                cmdCli.ExecuteNonQuery();

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

        private void DeleteClient()
        {
            try
            {
                string strCli = $"START TRANSACTION;" +
                    $" SET FOREIGN_KEY_CHECKS = 0;" +
                    $" DELETE FROM TBENDERECOCLI" +
                    $" WHERE CDENDERECO = '{idend}';" +
                    $" DELETE FROM TBCLIENTE" +
                    $" WHERE CDCLI = '{idcli}';" +
                    $" COMMIT;";  

                MySqlCommand cmdCli = new MySqlCommand(strCli, con.Connect());

                cmdCli.ExecuteNonQuery();

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
                txtIdCli.Text = dgvClients.SelectedRows[0].Cells[0].Value.ToString();
                txtNome.Text = dgvClients.SelectedRows[0].Cells[1].Value.ToString();
                txtSobreNome.Text = dgvClients.SelectedRows[0].Cells[2].Value.ToString();
                txtdtNasc.Text = dgvClients.SelectedRows[0].Cells[3].Value.ToString();
                txtIdEnd.Text = dgvClients.SelectedRows[0].Cells[4].Value.ToString();
                txtLogra.Text = dgvClients.SelectedRows[0].Cells[6].Value.ToString();
                txtNoResi.Text = dgvClients.SelectedRows[0].Cells[7].Value.ToString();
                lbEstados.SelectedItem = dgvClients.SelectedRows[0].Cells[8].Value.ToString();
                txtCidade.Text = dgvClients.SelectedRows[0].Cells[9].Value.ToString();
                txtBairro.Text = dgvClients.SelectedRows[0].Cells[10].Value.ToString();
                txtDesc.Text = dgvClients.SelectedRows[0].Cells[11].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível selecionar a informação requerida.\nMotivo do erro: " + ex, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvClients.DataSource = null;
            }
        }
    }
}

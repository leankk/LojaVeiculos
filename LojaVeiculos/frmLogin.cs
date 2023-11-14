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
    public partial class frmLogin : Form
    {
        Conexao con = new Conexao();

        public static string UserConnected;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dados = new DataTable();
            MySqlDataAdapter select = new MySqlDataAdapter("SELECT * FROM TBLOGIN WHERE NM_USUARIO=@USER AND ID_SENHA=@SENHA", con.Connect());
            select.SelectCommand.Parameters.AddWithValue("@USER", txtUsuario.Text);
            select.SelectCommand.Parameters.AddWithValue("@SENHA", txtSenha.Text);
            select.Fill(dados);

            if (txtUsuario.Text.Length == 0 || txtSenha.Text.Length == 0) 
            {
                MessageBox.Show("Digite um usuário e/ou senha!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Disconnect();
            }
            else if (dados.Rows.Count == 0)
            {
                MessageBox.Show("Usuário ou senha inválidos!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Disconnect();
            }
            else
            {
                frmSplash objSplash = new frmSplash();
                objSplash.ShowDialog();
                txtUsuario.Text = UserConnected;
                this.Close();
            }
        }
    
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}

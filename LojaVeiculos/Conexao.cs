using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaVeiculos
{
    internal class Conexao
    {
        MySqlConnection strCon = new MySqlConnection(@"Data Source=localhost; Initial Catalog=DBalphaspeed; UserID=; Pwd=");


        public MySqlConnection Connect()
        {
            try
            {
                strCon.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Não foi possível conectar ao banco de dados!\nMotivo do erro: " + ex, "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                strCon.Close();
            }
            return strCon;
        }

        public MySqlConnection Disconnect()
        {
            try
            {
                strCon.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Não foi possível desconectar ao banco de dados!\nMotivo do erro: " + ex, "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strCon;
        }
    }
}

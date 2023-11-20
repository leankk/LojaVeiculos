using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaVeiculos
{
    class formDAO
    {
        Conexao con = new Conexao();

        public void InsertClient()
        {


            string strCliSql = "INSERT INTO TBCLIENTE (NM_CLI, SOBRENOME_CLI, DT_NASC) AND VALUES (@nome, @sobrenome, STR_TO_DATE(@data, '%d/%m/%Y %T'));";
            MySqlCommand cmdCli = new MySqlCommand(strCliSql, con.Connect());

            cmdCli.Parameters.Add("@nome", MySqlDbType.VarChar);
            cmdCli.Parameters.Add("@sobrenome", MySqlDbType.VarChar);
            cmdCli.Parameters.Add("@data", MySqlDbType.Date);

            cmdCli.ExecuteNonQuery();

            MessageBox.Show("Dados cadastrados com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Disconnect();
        }

        public void InsertCars()
        {
            string strCarsSql = "INSERT INTO TBVEICULOS (NM_MODELO, NM_FABRICANTE, DS_COR) AND VALUES (@nome, @sobrenome, STR_TO_DATE(@data, '%d/%m/%Y %T'));";
            MySqlCommand cmdCars = new MySqlCommand(strCarsSql, con.Connect());

            cmdCars.Parameters.Add("@nome", MySqlDbType.VarChar);
            cmdCars.Parameters.Add("@sobrenome", MySqlDbType.VarChar);
            cmdCars.Parameters.Add("@data", MySqlDbType.Date);

            cmdCars.ExecuteNonQuery();

            MessageBox.Show("Dados cadastrados com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Disconnect();
        }
    }
}

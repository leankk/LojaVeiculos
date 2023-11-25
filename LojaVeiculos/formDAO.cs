using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaVeiculos
{
    public class formDAO
    {
        Conexao con = new Conexao();
        frmCliente cli;
        frmVeiculos vei;

        public void InsertClient()
        {
            cli = new frmCliente();

            string strCliSql = "INSERT INTO TBCLIENTE (NMNOME, NMSOBRENOME, DTNASCIMENTO) AND VALUES (@nome, @sobrenome, STR_TO_DATE(@data, '%d/%m/%Y %T'));";

            MySqlCommand cmdCli = new MySqlCommand(strCliSql, con.Connect());

            cmdCli.Parameters.Add("@nome", MySqlDbType.VarChar).Value = cli.nome;
            cmdCli.Parameters.Add("@sobrenome", MySqlDbType.VarChar).Value = cli.sobrenome;
            cmdCli.Parameters.Add("@data", MySqlDbType.Date).Value = cli.datanasc;
            cmdCli.ExecuteNonQuery();

            MessageBox.Show("Dados cadastrados com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Disconnect();
        }

        public void InsertCars()
        {
            vei = new frmVeiculos();

            //string strCarsSql = "INSERT INTO TBVEICULOS (NMMODELO, NMFABRICACAO, NOPLACA, NMMARCA, VLPRECO, DSCOR, DSDESCRICAO) AND VALUES (@modelo, @fab, @placa, @marca, @preco, @desc);";
            
            

           /* cmdCars.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = vei.modelo;
            cmdCars.Parameters.Add("@fab", MySqlDbType.VarChar).Value = vei.marca;
            cmdCars.Parameters.Add("@placa", MySqlDbType.VarChar).Value = vei.placa;
            cmdCars.Parameters.Add("@marca", MySqlDbType.VarChar).Value = vei.marca;
            cmdCars.Parameters.Add("@preco", MySqlDbType.Decimal).Value = vei.preco;
            cmdCars.Parameters.Add("@desc", MySqlDbType.VarChar).Value = vei.desc;*/

   
        }
    }
}

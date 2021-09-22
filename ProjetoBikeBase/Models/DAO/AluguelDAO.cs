using MySql.Data.MySqlClient;
using ProjetoBikeBase.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoBikeBase.Models.DAO
{
    public class AluguelDAO
    {
        Conexao con = new Conexao();
        public void TestarAgenda(AluguelDTO agenda)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbAluguel where DataAtend = @DataAtend and HoraAtend = @HoraAtend ", con.MyConectarBD());

            cmd.Parameters.Add("@DataAtend", MySqlDbType.VarChar).Value = agenda.DataAtend;
            cmd.Parameters.Add("@HoraAtend", MySqlDbType.VarChar).Value = agenda.HoraAtend;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                // while (leitor.Read())
                ///  {
                agenda.confAgendamento = "0";
                //   }

            }

            else
            {
                agenda.confAgendamento = "1";
            }

            con.MyDesConectarBD();
        }
        public void inserirAluguel(AluguelDTO cm)
        {

            MySqlCommand cmd = new MySqlCommand("insert into tbAluguel(DataAtend, HoraAtend, HrFinal, ValorTotal, IdCliente, IdProduto)" +
                                                "values (@DataAtend, @HoraAtend,@HrFinal, @ValorTotal,@IdCliente, @IdProduto)", con.MyConectarBD());

            //MySqlCommand cmd = new MySqlCommand("cadAluguel(@DataAtend, @HoraAtend,@HrFinal, @ValorTotal,@IdCliente, @IdProduto);", con.MyConectarBD());
            cmd.Parameters.Add("@DataAtend", MySqlDbType.VarChar).Value = cm.DataAtend;
            cmd.Parameters.Add("@HoraAtend", MySqlDbType.VarChar).Value = cm.HoraAtend;
            cmd.Parameters.Add("@HrFinal", MySqlDbType.VarChar).Value = cm.HrFinal;
            cmd.Parameters.Add("@ValorTotal", MySqlDbType.VarChar).Value = cm.ValorTotal;
            cmd.Parameters.Add("@IdCliente", MySqlDbType.Int32).Value = cm.IdCliente;
            cmd.Parameters.Add("@IdProduto", MySqlDbType.Int32).Value = cm.IdProduto;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public DataTable selecionaAlugel()
        {
            //MySqlCommand cmd = new MySqlCommand("Select * from tbAtendimento", con.MyConectarBD());
                MySqlCommand cmd = new MySqlCommand("SELECT t1.IdAluguel as Código,t2.nomeCliente as Cliente,t3.NomeProd as Bicicleta," +
                                           " t1.DataAtend as Data,t1.horaAtend As Inicil,t1.hrFinal As Fianal " +
                                           " FROM tbAluguel as t1 " +
                                           " INNER JOIN tbCliente as t2 ON t1.IdCliente = t2.IdCliente " +
                                               " INNER JOIN tbProduto as t3 ON t1.IdProduto = t3.IdProduto; ", con.MyConectarBD());
            //MySqlCommand cmd = new MySqlCommand("CALL SelecionarAluguel( )", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable atend = new DataTable();
            da.Fill(atend);
            con.MyDesConectarBD();
            return atend;
        }

    }
}
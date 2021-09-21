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

            //MySqlCommand cmd = new MySqlCommand("insert into tbAluguel(DataAtend, HoraAtend, HrFinal, ValorTotal, IdCliente, IdProduto)" +
            //                                    "values (@DataAtend, @HoraAtend,@HrFinal, @ValorTotal,@IdCliente, @IdProduto)", con.MyConectarBD());
            
            MySqlCommand cmd = new MySqlCommand("cadAluguel(@DataAtend, @HoraAtend,@HrFinal, @ValorTotal,@IdCliente, @IdProduto)", con.MyConectarBD());
            cmd.Parameters.Add("@DataAtend", MySqlDbType.VarChar).Value = cm.DataAtend;
            cmd.Parameters.Add("@HoraAtend", MySqlDbType.VarChar).Value = cm.HoraAtend;
            cmd.Parameters.Add("@HrFinal", MySqlDbType.VarChar).Value = cm.HrFinal;
            cmd.Parameters.Add("@ValorTotal", MySqlDbType.VarChar).Value = cm.ValorTotal;
            cmd.Parameters.Add("@IdCliente", MySqlDbType.VarChar).Value = cm.IdCliente;
            cmd.Parameters.Add("@IdProduto", MySqlDbType.VarChar).Value = cm.IdProduto;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public DataTable selecionaAlugel()
        {
            // MySqlCommand cmd = new MySqlCommand("Select * from tbAtendimento", con.MyConectarBD());
            MySqlCommand cmd = new MySqlCommand("select t1.codAtend as Código,t2.nomeMedico as Médico,t3.nomePac as Paciente,t4.especialidade as Especialidade," +
                                                " t1.dataAtend as Data,t1.horaAtend as Hora from tbAtendimento as t1" +
                                                " INNER JOIN tbmedico as t2 ON t1.codMedico = t2.codMedico " +
                                                " INNER JOIN tbesp as t4 ON t4.codEspecialidade = t2.codEspecialidade" +
                                                " INNER JOIN tbPaciente as t3 ON t3.codPac = t1.codPac; ", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable atend = new DataTable();
            da.Fill(atend);
            con.MyDesConectarBD();
            return atend;
        }

    }
}
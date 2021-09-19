using MySql.Data.MySqlClient;
using ProjetoBikeBase.Models.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProjetoBikeBase.Models.DAO
{
    public class ClienteDAO
    {
        String _conexaoMySQL = null;
        MySqlConnection con = null;

        //String Conexão
        public ClienteDAO()
        {
            _conexaoMySQL = ConfigurationManager.ConnectionStrings["conexaoMySQL"].ToString();
        }
        public void inserirCliente(ClienteDTO cliente)
        {
            try
            {
                //String sql = "INSERT INTO tbCliente (NomeCliente, CPFCliente, TelCliente, EmailCliente, EndCliente, NascCli) " +
                //                           " VALUES (@NomeCliente, @CPFCliente, @TelCliente, @EmailCliente, @EndCliente, @NascCli)";

                String sql = "CALL cadCliente(@NomeCliente, @CPFCliente, @TelCliente, @EmailCliente, @EndCliente, @NascCli)";
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@NomeCliente", cliente.NomeCliente);
                cmd.Parameters.AddWithValue("@CPFCliente", cliente.CPFCliente);
                cmd.Parameters.AddWithValue("@TelCliente", cliente.TelCliente);
                cmd.Parameters.AddWithValue("@EmailCliente", cliente.EmailCliente);
                cmd.Parameters.AddWithValue("@EndCliente", cliente.EndCliente);
                cmd.Parameters.AddWithValue("@NascCli", Convert.ToDateTime(cliente.NascCli));

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro cliente" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro cliente" + ex.Message);
            }
            finally
            {
                con.Close();
            }
     }   }
}
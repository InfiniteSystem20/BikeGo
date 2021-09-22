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
        //CADASTRO CLIENTE
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
        }
        //LISTAR CLIENTE
        public List<ClienteDTO> selectListCliente()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    // using (MySqlCommand command = new MySqlCommand("Select * from tbCliente", conn))
                    using (MySqlCommand command = new MySqlCommand("call SelecionarCliente();", conn))
                    //
                    {
                        conn.Open();
                        List<ClienteDTO> listaCliente = new List<ClienteDTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ClienteDTO cliente = new ClienteDTO();
                                cliente.IdCliente = (int)dr["IdCliente"];
                                cliente.NomeCliente = (String)dr["NomeCliente"];
                                cliente.CPFCliente = (String)dr["CPFCliente"];
                                cliente.TelCliente = (String)dr["TelCliente"];
                                cliente.EmailCliente = (String)dr["EmailCliente"];
                                cliente.EndCliente = (String)dr["EndCliente"];                                
                                cliente.NascCli = Convert.ToDateTime(dr["NascCli"]).ToString("dd'/'MM'/'yyyy");

                                listaCliente.Add(cliente);
                            }
                        }
                        return listaCliente;
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao Listar usuario" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao Listar usuario" + ex.Message);
            }
        }
        // UPDATE CLIENTE
        public void updateCliente(ClienteDTO cliente)
        {
            try
            {
                String sql = " UPDATE tbCliente SET NomeCliente=@NomeCliente,CPFCliente=@CPFCliente,TelCliente=@TelCliente, " +
                            " EmailCliente=@EmailCliente, EndCliente=@EndCliente, NascCli=@NascCli   WHERE IdCliente = @IdCliente ";
                //String sql = " CALL AlterCliente()NomeCliente=@NomeCliente,CPFCliente=@CPFCliente,TelCliente=@TelCliente," +
                //             " EmailCliente=@EmailCliente, EndCliente=@EndCliente, NascCli=@NascCli   WHERE IdCliente = @IdCliente";

                //AlterCliente
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
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

                throw new Exception("Erro no banco ao atualizar dados do Cliente" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao atualizar dados do Cliente" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
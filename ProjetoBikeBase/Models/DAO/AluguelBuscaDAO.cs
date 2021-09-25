using MySql.Data.MySqlClient;
using ProjetoBikeBase.Models.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProjetoBikeBase.Models.DAO
{
    public class AluguelBuscaDAO
    {
        String _conexaoMySQL = null;
        MySqlConnection con = null;

        //String Conexão
        public AluguelBuscaDAO()
        {
            _conexaoMySQL = ConfigurationManager.ConnectionStrings["conexaoMySQL"].ToString();
        }
        public List<AluguelBuscaDTO> selectListAluguel()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conexaoMySQL))
                {
                    // using (MySqlCommand command = new MySqlCommand("Select * from tbCliente", conn))
                    using (MySqlCommand command = new MySqlCommand("CALL SelecionarAluguel( )", conn))
                    //
                    {
                        conn.Open();
                        List<AluguelBuscaDTO> listaAluguel = new List<AluguelBuscaDTO>();
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                AluguelBuscaDTO aluguel = new AluguelBuscaDTO();
                                aluguel.IdAluguel = (int)dr["Código"];
                                aluguel.NomeCliente = (String)dr["Cliente"];
                                aluguel.Bicicleta = (String)dr["Bicicleta"];
                                aluguel.DataAtend = Convert.ToDateTime( dr["Data"]).ToString("dd'/'MM'/'yyyy");
                                aluguel.HoraAtend = (String)dr["Inicil"];
                                aluguel.HrFinal = (String)dr["Final"];
                                aluguel.ValorTotal = (decimal)dr["Total"];

                                listaAluguel.Add(aluguel);
                            }
                        }
                        return listaAluguel;
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
        //CANCELAR ALUGUEL
        public void CancelarAluguel(AluguelBuscaDTO aluguel)
        {
            string StatusAlug = "Cancelado";

            try
            {
                String sql = "UPDATE tbAluguel set StatusAlug = @StatusAlug where IdAluguel = @IdAluguel ";

                //String sql = " UPDATE tbAluguel SET NomeCliente=@NomeCliente,CPFCliente=@CPFCliente,TelCliente=@TelCliente, " +
                //            " EmailCliente=@EmailCliente, EndCliente=@EndCliente, NascCli=@NascCli   WHERE IdCliente = @IdCliente ";

                //String sql = " CALL AlterCliente()NomeCliente=@NomeCliente,CPFCliente=@CPFCliente,TelCliente=@TelCliente," +
                //             " EmailCliente=@EmailCliente, EndCliente=@EndCliente, NascCli=@NascCli   WHERE IdCliente = @IdCliente";

                //AlterCliente
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdAluguel", aluguel.IdAluguel);
                cmd.Parameters.AddWithValue("@StatusAlug", StatusAlug);
                ;

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco ao atualizar dados do Aluguel" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação ao atualizar dados do Aluguel" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
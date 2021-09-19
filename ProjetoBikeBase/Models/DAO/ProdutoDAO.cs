using MySql.Data.MySqlClient;
using ProjetoBikeBase.Models.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProjetoBikeBase.Models.DAO
{
    public class ProdutoDAO
    {
        String _conexaoMySQL = null;
        MySqlConnection con = null;

        //String Conexão
        public ProdutoDAO()
        {
            _conexaoMySQL = ConfigurationManager.ConnectionStrings["conexaoMySQL"].ToString();
        }
        public void inserirProduto(ProdutoDTO cliente)
        {
            try
            {
                /*String sql = "insert into tbProduto(NomeProd, Qtd, Valor, StatusProd)"
                  values (@NomeProd, @Qtd, @Valor, @StatusProd);*/

                String sql = "CALL cadProduto(@NomeProd, @Qtd, @Valor, @StatusProd)";
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@NomeProd", cliente.NomeProd);
                cmd.Parameters.AddWithValue("@Qtd", cliente.Qtd);
                cmd.Parameters.AddWithValue("@Valor", cliente.Valor);
                cmd.Parameters.AddWithValue("@StatusProd", cliente.StatusProd);


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
    }
}
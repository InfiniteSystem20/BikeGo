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
        public void inserirProduto(ProdutoDTO produto)
        {
            try
            {
<<<<<<< HEAD
                String sql = "insert into tbProduto(NomeProd, Qtd, Valor, StatusProd)" +
                  "values(@NomeProd, @Qtd, @Valor, @StatusProd)";
=======
                /*String sql = "insert into tbProduto(NomeProd, Qtd, Valor, StatusProd)"+
                  "values (@NomeProd, @Qtd, @Valor, @StatusProd)";*/
>>>>>>> 05391b9a14bcacc2c343b701559e39e20e85e26e

                //String sql = "CALL cadProduto(@NomeProd, @Qtd, @Valor, @StatusProd)";
                con = new MySqlConnection(_conexaoMySQL);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@NomeProd", produto.NomeProd);
                cmd.Parameters.AddWithValue("@Qtd", produto.Qtd);
                cmd.Parameters.AddWithValue("@Valor", produto.Valor);
                cmd.Parameters.AddWithValue("@StatusProd", produto.StatusProd);


                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {

                throw new Exception("Erro no banco em cadastro produto" + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro na aplicação em cadastro produto" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
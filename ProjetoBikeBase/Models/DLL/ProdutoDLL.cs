using ProjetoBikeBase.Models.DAO;
using ProjetoBikeBase.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBikeBase.Models.DLL
{
    public class ProdutoDLL
    {
        ProdutoDAO dal = null;
        public ProdutoDLL() { }

        public void novoProduto(ProdutoDTO produtoDto )
        {
            try
            {
                dal = new ProdutoDAO();
                dal.inserirProduto(produtoDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
using ProjetoBikeBase.Models.DLL;
using ProjetoBikeBase.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBikeBase.Controllers
{
    public class ProdutoController : Controller
    {
        ProdutoDLL produtoDLL = new ProdutoDLL();
        ProdutoDTO produtoDTO = new ProdutoDTO();

        public ActionResult CadastroProduto()
        {
            return View();
        }


        // CADASTRAR PRODUTO
        [HttpPost]
        public ActionResult CadastroProduto(ProdutoDTO produto)
        
        {
            if (ModelState.IsValid)
            {
                produtoDLL.novoProduto(produto);

                ViewBag.msg = "Produto cadastrado com sucesso!";
                return RedirectToAction(nameof(ListarProduto));

                
                
            }
            return View();
        }
        //LISTA DE PRODUTOS
        public ActionResult ListarProduto()
        {
            return View(produtoDLL.listaProduto());
        }

    }
}
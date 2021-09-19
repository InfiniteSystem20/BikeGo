using ProjetoBikeBase.Models.DLL;
using ProjetoBikeBase.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBikeBase.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDLL clienteDLL = new ClienteDLL();
        ClienteDTO clienteDTO = new ClienteDTO();

        // CADASTRAR CLIENTE
        public ActionResult CadastroCliente()
        {
            return View();
        }


        // CADASTRAR CLIENTE
        [HttpPost]
        public ActionResult CadastroCliente(ClienteDTO cliente)
        {
            if (ModelState.IsValid)
            {
                clienteDLL.novoCliente(cliente);


                return RedirectToAction(nameof(CadastroCliente));

                /* ViewBag.msg = "Cliente cadastrado com sucesso!";
                    return View();
                */
            }
            return View();
        }
        public ActionResult ListarCliente()
        {
            return View(clienteDLL.listaCliente());
        }

        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
    }
}
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


                return RedirectToAction(nameof(ListarCliente));

                /* ViewBag.msg = "Cliente cadastrado com sucesso!";
                    return View();
                */
            }
            return View();
        }
        //LISTAR CLIENTE
        public ActionResult ListarCliente()
        {
            return View(clienteDLL.listaCliente());
        }
        // UPDATE CLIENTE        
        public ActionResult EditarCliente(int id)
        {
            return View(clienteDLL.listaCliente().Find(clienteDTO => clienteDTO.IdCliente == id));
        }
        // EDITAR CLIENTE
        [HttpPost]
        public ActionResult EditarCliente(ClienteDTO cl)
        {
            clienteDLL.alteraCliente(cl);
            return RedirectToAction(nameof(ListarCliente));
        }
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
    }
}
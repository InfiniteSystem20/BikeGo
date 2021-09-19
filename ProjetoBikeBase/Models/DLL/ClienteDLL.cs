using ProjetoBikeBase.Models.DAO;
using ProjetoBikeBase.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBikeBase.Models.DLL
{
    public class ClienteDLL
    {
        ClienteDAO dal = null;
        public ClienteDLL() { }
        //CADASTRO DE CLIENTE
        public void novoCliente(ClienteDTO clienteDto)
        {
            try
            {
                dal = new ClienteDAO();
                dal.inserirCliente(clienteDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //SELECIONA LISTA de CLIENTE
        public List<ClienteDTO> listaCliente()
        {
            try
            {
                dal = new ClienteDAO();
                return dal.selectListCliente();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
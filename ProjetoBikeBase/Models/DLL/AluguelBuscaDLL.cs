using ProjetoBikeBase.Models.DAO;
using ProjetoBikeBase.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBikeBase.Models.DLL
{
    public class AluguelBuscaDLL
    {
        AluguelBuscaDAO dal = null;
        public AluguelBuscaDLL() { }

        //SELECIONA LISTA de ALUGUEL
        public List<AluguelBuscaDTO> listaAluguel()
        {
            try
            {
                dal = new AluguelBuscaDAO();
                return dal.selectListAluguel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //SELECIONA LISTA de ALUGUEL DETALHES
        public List<AluguelBuscaDTO> listaAluguelDetalhes()
        {
            try
            {
                dal = new AluguelBuscaDAO();
                return dal.selectListAluguelDetalhes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CANCELAR ALUGUEL
        public void CancelarAlugeul(AluguelBuscaDTO Aluguel)
        {
            try
            {
                dal = new AluguelBuscaDAO();
                dal.CancelarAluguel(Aluguel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
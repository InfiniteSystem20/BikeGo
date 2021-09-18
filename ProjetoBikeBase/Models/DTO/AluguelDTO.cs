using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBikeBase.Models.DTO
{
    public class AluguelDTO
    {
        public int IdAluguel { get; set; }
        public string IdCliente { get; set; }
        public string IdProduto { get; set; }
        public string DataAtend { get; set; }
        public string HoraAtend { get; set; }
        public string HrFinal { get; set; }
        public decimal ValorTotal { get; set; }

        public string confAgendamento { get; set; }
    }
}
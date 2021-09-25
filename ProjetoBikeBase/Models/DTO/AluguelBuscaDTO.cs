using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoBikeBase.Models.DTO
{
    public class AluguelBuscaDTO
    {
        [Display(Name = "Código")]
        public int IdAluguel { get; set; }

        [Display(Name = "Nome do Cliente")]
        public string NomeCliente { get; set; }

        [Display(Name = "Bicicleta")]
        public string Bicicleta { get; set; }

        [Display(Name = "Data Aluguel")]
        public string DataAtend { get; set; }

        [Display(Name = "Hr. Início")]
        public string HoraAtend { get; set; }

        [Display(Name = "Hr. Final")]
        public string HrFinal { get; set; }
        public string StatusAlug { get; set; }

        [Display(Name = "Valor Total")]
        public decimal ValorTotal { get; set; }
    }
}
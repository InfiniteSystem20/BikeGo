using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoBikeBase.Models.DTO
{
    public class ClienteDTO
    {
        [Display(Name = "Código")]
        public int IdCliente { get; set; }

        [Display(Name = "Nome")]
        public string NomeCliente { get; set; }

        [Display(Name = "CPF")]
        public string CPFCliente { get; set; }

        [Display(Name = "E-mail")]
        public string EmailCliente { get; set; }

        [Display(Name = "Telefone")]
        public string TelCliente { get; set; }

        [Display(Name = "Endereço")]
        public string EndCliente { get; set; }

        [Display(Name = "Dt. Nascimento")]
        public string NascCli { get; set; }
    }
}
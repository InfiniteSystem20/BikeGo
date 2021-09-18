using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoBikeBase.Models.DTO
{
    public class ProdutoDTO
    {
        [Display(Name = "Código")]
        public int IdProduto { get; set; }

        [Display(Name = "Nome")]
        public string NomeProd { get; set; }

        [Display(Name = "Quatidade")]
        public int Qtd { get; set; }

        [Display(Name = "Valor por hora")]
        public decimal Valor { get; set; }

        [Display(Name = "Status")]
        public string StatusProd { get; set; }
    }
}
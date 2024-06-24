using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet.Models
{
    public class TransacaoModel
    {
        public int? Id {get; set; }
        public string? Historico {get;set;}
        public DateTime Data {get;set;}

        [Required(ErrorMessage = "Informe o valor da Transação")]
        public decimal Valor {get;set;}
        public int PlanoContaId {get;set;}
        public PlanoContaModel? ItemPlanoConta {get;set;}

        public IEnumerable<SelectListItem>? PlanoContas {get;set;}
    }
}


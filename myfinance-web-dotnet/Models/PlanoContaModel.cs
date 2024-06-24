using System.ComponentModel.DataAnnotations;

namespace myfinance_web_dotnet.Models
{
    public class PlanoContaModel
    {
        public int Id {get; set; }

        [Required(ErrorMessage = "Informe a descrição do item de Plano de conta")]
        public string Descricao{get;set;}
        
        [Required(ErrorMessage = "Informe o tipo do item de Plano de conta")]
        public string Tipo {get;set;}
    }
}
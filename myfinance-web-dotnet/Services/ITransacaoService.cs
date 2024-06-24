using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Services
{
    public interface ITransacaoService
    {
         List<TransacaoModel> listarRegistros();
         void salvar (TransacaoModel model);

         void excluir (int id);

         TransacaoModel retornarRegistro (int id);
    }
}
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Services
{
    public interface IPlanoService
    {
         List<PlanoContaModel> listarRegistros();
         void salvar (PlanoContaModel model);

         void excluir (int id);

         PlanoContaModel retornarRegistro (int id);
    }
}
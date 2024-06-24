using AutoMapper;
using myfinance_web_dotnet.Controllers;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.infraestructure;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Services
{
    public class PlanoService  : IPlanoService {

         private readonly MyFinanceDbContext _myFinanceDbContext;
         private readonly IMapper _mapper;

         public PlanoService(MyFinanceDbContext myFinanceDbContext, IMapper mapper){
           _myFinanceDbContext =  myFinanceDbContext;
           _mapper =  mapper;
         }

        public List<PlanoContaModel> listarRegistros()
        {
           var listaPlanoConta =_myFinanceDbContext.PlanoConta.ToList();
           var lista = _mapper.Map<List<PlanoContaModel>>(listaPlanoConta);
           return lista;
        }

        public void salvar(PlanoContaModel model)
        {
            var dbSet = _myFinanceDbContext.PlanoConta;
            var item = _mapper.Map<PlanoConta>(model);

     
            if(item.Id == 0){
                dbSet.Add(item);
            }
              
            else{
                dbSet.Attach(item);
                _myFinanceDbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();
        }

        void IPlanoService.excluir(int id)
        {
            var item = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).First();
            _myFinanceDbContext.Attach(item);
            _myFinanceDbContext.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }

        public PlanoContaModel retornarRegistro(int id)
        {
           var item = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).First();
           var registro = _mapper.Map<PlanoContaModel>(item);
           return registro;
        }
    }



}
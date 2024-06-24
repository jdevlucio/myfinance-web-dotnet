using AutoMapper;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Mappers
{
    public class PlanoContaMap : Profile
    {
         public PlanoContaMap(){
            CreateMap<PlanoConta, PlanoContaModel>().ReverseMap();
         }
    }
}
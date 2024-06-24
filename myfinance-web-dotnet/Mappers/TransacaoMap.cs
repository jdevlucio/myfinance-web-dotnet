using AutoMapper;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Mappers
{
    public class TransacaoMap : Profile
    {
         public TransacaoMap(){
            CreateMap<Transacao, TransacaoModel>()
            .ForMember(dest => dest.ItemPlanoConta, opt => opt.MapFrom(src => src.PlanoConta))
            .ReverseMap();
         }
    }
}
using System.Linq;
using AutoMapper;
using ProAgil.Domain;
using ProAgil.Domain.Identity;
using ProAgil.WebAPI.Dtos;

namespace ProAgil.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //aqui basicamente os dados vão sair de Evento e vão para o EventoDto. Isso é feito em relação de muitos p/ muitos
            // ReverseMap serve para inverter a ordem de inserção ex: dest é palestrante e src é palestrante evento... 
            // Com o reverseMap no final, automaticamnete o sistema deixa dest =>palestrante evento e src=>palestrante.  
            CreateMap<Evento, EventoDto>()
                .ForMember(dest => dest.Palestrantes, opt =>{
                    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
                }).ReverseMap();

            CreateMap<Palestrante, PalestranteDto>()
                .ForMember(dest => dest.Eventos, opt => {
                    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
                }).ReverseMap();

            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            
        }
    }
}
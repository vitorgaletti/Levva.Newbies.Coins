using AutoMapper;
using Levva.Newbies.Coins.Domain.Models;
using Levva.Newbies.Coins.Business.Dtos;

namespace Levva.Newbies.Coins.Business.MapperProfiles {
    public class DefaultMapper : Profile {

        public DefaultMapper() {
            CreateMap<UsuarioDto, Usuario>().ReverseMap();
            CreateMap<TransacaoDto, Transacao>().ReverseMap();
            CreateMap<CategoriaDto, Categoria>().ReverseMap();
        }
    }
}

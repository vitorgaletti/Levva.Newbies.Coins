using AutoMapper;
using Levva.Newbies.Coins.Domain.Models;
using Levva.Newbies.Coins.Business.Dtos;

namespace Levva.Newbies.Coins.Business.MapperProfiles {
    public class DefaultMapper : Profile {

        public DefaultMapper() {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<TransactionDto, Transaction>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}

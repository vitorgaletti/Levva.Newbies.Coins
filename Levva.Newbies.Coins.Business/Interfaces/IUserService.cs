using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbies.Coins.Business.Interfaces {
    public interface IUserService {
        Task<ResultService<UserDto>> Create(UserDto user);
        Task<ResultService<UserDto>> Get(Guid Id);
        List<UserDto> GetAll();
        Task<ResultService> Update(Guid id, UpdateUserDto name);
        void Delete(Guid Id);
        Task<ResultService<LoginDto>> Login(LoginDto login);
    }
}

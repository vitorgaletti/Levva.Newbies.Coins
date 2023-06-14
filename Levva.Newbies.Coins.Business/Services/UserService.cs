using AutoMapper;
using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;
using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Levva.Newbies.Coins.Business.Dtos.Validations;
using Microsoft.Extensions.Options;
using FluentValidation;

namespace Levva.Newbies.Coins.Business.Services {
    public class UserService : IUserService {

        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository repository, IMapper mapper, IConfiguration configuration) {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ResultService<UserDto>> Create(UserDto userDto) {

            if (userDto == null) {
                return ResultService.Fail<UserDto>("Objeto deve ser informado.");
            }

            var result = new UserDtoValidator().Validate(userDto);

            if (!result.IsValid)
                return ResultService.RequestError<UserDto>("Problema de validade!", result);

            var user = await _repository.CheckEmailAlreadyExists(userDto.Email);

            if (user != null) {
                return ResultService.Fail<UserDto>("Esse e-mail já existe.");
            }

            var _user = _mapper.Map<User>(userDto);
            await _repository.Create(_user);

            return ResultService.Ok(userDto);

        }
        public async Task<ResultService<UserDto>> Get(Guid Id) {
            var user = await _repository.CheckIfUserExists(Id);

            if (user == null) return ResultService.Fail<UserDto>("Esse usuário não existe.");

            var _user = _mapper.Map<UserDto>(user);

            _user.Password = null;

            return ResultService.Ok(_user);
        }

        public List<UserDto> GetAll() {
            var users = _mapper.Map<List<UserDto>>(_repository.GetAll());
            return users;
        }

        public async Task<ResultService> Update(Guid id, UpdateUserDto userDto) {

            var user = await _repository.CheckIfUserExists(id);

            if (user == null) return ResultService.Fail("Esse usuário não existe.");

            user.Name = userDto.Name;

            var _user = _mapper.Map<User>(user);
            await _repository.Update(_user);

            return ResultService.Ok("Usuário editado");
        }

        public void Delete(Guid Id) {
            _repository.Delete(Id);
        }

        public async Task<ResultService<LoginDto>> Login(LoginDto loginDto) {

            if (loginDto == null)
                return ResultService.Fail<LoginDto>("Informe email e senha.");

            var result = new LoginDtoValidator().Validate(loginDto);

            if (!result.IsValid)
                return ResultService.RequestError<LoginDto>("Problema de validade!", result);

            var user = await _repository.GetByEmailAndPassword(loginDto.Email, loginDto.Password);

            if (user == null) {
                return ResultService.Fail<LoginDto>("Usuário ou senha inválidos.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            loginDto.Token = tokenHandler.WriteToken(token);
            loginDto.Id = user.Id;
            loginDto.Name = user.Name;
            loginDto.Email = user.Email;
            loginDto.Password = null;

            return ResultService.Ok<LoginDto>(loginDto);
        }


    }
}

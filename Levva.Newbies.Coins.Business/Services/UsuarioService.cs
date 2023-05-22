﻿using AutoMapper;
using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;
using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Levva.Newbies.Coins.Business.Services {
    public class UsuarioService : IUsuarioService {

        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UsuarioService(IUsuarioRepository repository, IMapper mapper, IConfiguration configuration) {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public void Create(UsuarioDto usuario) {
            var _usuario = _mapper.Map<Usuario>(usuario);
            _repository.Create(_usuario);
        }
        public UsuarioDto Get(int Id) {
            var usuario = _mapper.Map<UsuarioDto>(_repository.Get(Id));
            return usuario;
        }

        public List<UsuarioDto> GetAll() {
            var usuarios = _mapper.Map<List<UsuarioDto>>(_repository.GetAll());
            return usuarios;
        }

        public void Update(UsuarioDto usuario) {
            var _usuario = _mapper.Map<Usuario>(usuario);
            _repository.Update(_usuario);
        }

        public void Delete(int Id) {
            _repository.Delete(Id);
        }

        public LoginDto Login(LoginDto loginDto) {
            var usuario = _repository.GetByEmailAndSenha(loginDto.Email, loginDto.Senha);

            if (usuario == null) {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, usuario.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            loginDto.Token = tokenHandler.WriteToken(token);
            loginDto.Nome = usuario.Nome;
            loginDto.Email = usuario.Email;
            loginDto.Senha = null;

            return loginDto;

            
        }
    }
}

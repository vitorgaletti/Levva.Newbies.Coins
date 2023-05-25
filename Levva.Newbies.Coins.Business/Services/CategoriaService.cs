using AutoMapper;
using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;
using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Interfaces;

namespace Levva.Newbies.Coins.Business.Services {
    public class CategoriaService : ICategoriaService {
        
        private readonly IRepository<Categoria> _repository;
        private readonly IMapper _mapper;

        public CategoriaService(IRepository<Categoria> repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(CategoriaDto categoria) {
            var _categoria = _mapper.Map<Categoria>(categoria);
            _repository.Create(_categoria);
        }
        public CategoriaDto Get(int Id) {
            var categoria = _mapper.Map<CategoriaDto>(_repository.Get(Id));
            return categoria;
        }

        public List<CategoriaDto> GetAll() {
            var categorias = _mapper.Map<List<CategoriaDto>>(_repository.GetAll());
            return categorias;
        }

        public void Update(CategoriaDto categoria) {
            var _categoria = _mapper.Map<Categoria>(categoria);
            _repository.Update(_categoria);
        }

        public void Delete(int Id) {
            _repository.Delete(Id);
        }
    }
}

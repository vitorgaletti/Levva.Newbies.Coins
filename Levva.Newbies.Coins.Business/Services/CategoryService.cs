using AutoMapper;
using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;
using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Interfaces;
using Levva.Newbies.Coins.Business.Dtos.Validations;

namespace Levva.Newbies.Coins.Business.Services {
    public class CategoryService : ICategoryService {

        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultService<CategoryDto>> Create(CategoryDto categoryDto) {

            if (categoryDto == null) return ResultService.Fail<CategoryDto>("Objeto deve ser informado.");

            var result = new CategoryDtoValidator().Validate(categoryDto);

            if (!result.IsValid)
                return ResultService.RequestError<CategoryDto>("Problema de validade!", result);

            var category = await _repository.CheckDescriptionAlreadyExists(categoryDto.Description);

            if (category != null) {
                return ResultService.Fail<CategoryDto>("Uma categoria com esse nome já existe.");
            }

            var _category = _mapper.Map<Category>(categoryDto);
            await _repository.Create(_category);

            var categoryCreated = _mapper.Map<CategoryDto>(_category);

            return ResultService.Ok<CategoryDto>(categoryCreated);
        }
        public CategoryDto Get(Guid Id) {
            var category = _mapper.Map<CategoryDto>(_repository.Get(Id));
            return category;
        }

        public async Task<List<CategoryDto>> GetAll() {
            var categories =  await _repository.GetAllCategories();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
        public void Update(CategoryDto category) {
            var _category = _mapper.Map<Category>(category);
            _repository.Update(_category);
        }

        public void Delete(Guid Id) {
            _repository.Delete(Id);
        }


    }
}

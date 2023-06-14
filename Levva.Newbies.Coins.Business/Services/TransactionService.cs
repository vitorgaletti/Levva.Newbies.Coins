using AutoMapper;
using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;
using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Interfaces;
using Levva.Newbies.Coins.Business.Dtos.Validations;

namespace Levva.Newbies.Coins.Business.Services {
    public class TransactionService : ITransactionService {

        private readonly ITransactionRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository repository, IMapper mapper, IUserRepository userRepository, ICategoryRepository categoryRepository) {
            _repository = repository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<TransactionDto>> Create(TransactionDto transactionDto) {

            if (transactionDto == null)
                return ResultService.Fail<TransactionDto>("Objeto deve ser informado");

            var result = new TransactionDtoValidator().Validate(transactionDto);

            if (!result.IsValid)
                return ResultService.RequestError<TransactionDto>("Erro de validação", result);

            var category = await _categoryRepository.CheckCategoryExists(transactionDto.CategoryId);

            if (category == null)
                return ResultService.Fail<TransactionDto>("Categoria não encontrada.");

            var _transaction = _mapper.Map<Transaction>(transactionDto);

            var userId = await _userRepository.GetIdByEmailUser(transactionDto.UserEmail);

            if (userId == Guid.Empty)
                return ResultService.Fail<TransactionDto>("Usuário não encontrado.");

            _transaction.UserId = userId;

            _transaction.CreatedAt = DateTime.Now;

            await _repository.Create(_transaction);

            var categoryDescription = await _repository.GetTransactionByCategoryId(_transaction.CategoryId);
            _transaction.Category.Description = categoryDescription;

            var createdTransaction = _mapper.Map<TransactionDto>(_transaction);

            return ResultService.Ok(createdTransaction);
        }

        public TransactionDto Get(Guid Id) {
            var transaction = _mapper.Map<TransactionDto>(_repository.Get(Id));
           return transaction;
        }

        public List<TransactionDto> GetAll(string? search, int limit, int offset) {
            var transactions = _mapper.Map<List<TransactionDto>>(_repository.GetAll(search, limit, offset));
            return transactions;
        }

        public void Update(TransactionDto transaction) {
            var _transaction = _mapper.Map<Transaction>(transaction);
            _repository.Update(_transaction);
        }

        public async Task<ResultService> Delete(Guid id) {

            var transaction = await _repository.CheckIfTransactionExists(id);

            if (transaction == null)
                return ResultService.Fail("Essa transação não existe.");

            _repository.Delete(id);

            return ResultService.Ok("Transação removida.");
        }
    }
}

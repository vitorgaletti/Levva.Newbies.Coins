using FluentValidation;

namespace Levva.Newbies.Coins.Business.Dtos.Validations {
    public class TransactionDtoValidator : AbstractValidator<TransactionDto>{

        public TransactionDtoValidator() {

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descrição é obrigatório.");

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Preço deve ser maior do que zero.");
        }
    }
}

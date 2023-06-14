using FluentValidation;

namespace Levva.Newbies.Coins.Business.Dtos.Validations {
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>{
        public CategoryDtoValidator() {

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descrição é obrigatório.");
        }
    }
}

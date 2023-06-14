using FluentValidation;

namespace Levva.Newbies.Coins.Business.Dtos.Validations {
    public class UserDtoValidator : AbstractValidator<UserDto>{
        public UserDtoValidator() {

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email é obrigatório.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Senha é obrigatória.");
        }
    }
}

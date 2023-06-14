using FluentValidation;

namespace Levva.Newbies.Coins.Business.Dtos.Validations {
    public class LoginDtoValidator : AbstractValidator<LoginDto>{
        public LoginDtoValidator() {

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

using FluentValidation;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class PrincipalAddCommandValidation : AbstractValidator<PrincipalAddCommand>
    {
        public PrincipalAddCommandValidation()
        {
            RuleFor(x => x.UserId)
               .NotEmpty();

            RuleFor(x => x.IdentityProvider)
                .NotEmpty();

            RuleFor(x => x.UserDetails)
                .NotEmpty();

            RuleFor(x => x.UserRoles)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
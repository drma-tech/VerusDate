using FluentValidation;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileLookingValidation : AbstractValidator<ProfilePreferenceModel>
    {
        public ProfileLookingValidation()
        {
            RuleFor(x => x.Region)
                .NotEmpty();

            RuleFor(x => x.Change)
                .NotEmpty();

            RuleFor(x => x.MinimalAge)
                .NotEmpty()
                .GreaterThanOrEqualTo(18);

            RuleFor(x => x.MaxAge)
                .NotEmpty()
                .LessThanOrEqualTo(120);

            RuleFor(x => x.MinimalAge)
                .Must((value, MinimalAge) => MinimalAge <= value.MaxAge)
                .WithMessage("A idade mínima deve ser menor que a idade máxima");

            RuleFor(x => x.MaxAge)
                .Must((value, MaxAge) => MaxAge >= value.MinimalAge)
                .WithMessage("A idade máxima deve ser maior que a idade mínima");

            RuleFor(x => x.MinimalHeight)
                .Must((value, MinimalHeight) => MinimalHeight <= value.MaxHeight)
                .WithMessage("A altura mínima deve ser menor que a altura máxima")
                .When(x => x.MinimalHeight.HasValue && x.MaxHeight.HasValue);

            RuleFor(x => x.MaxHeight)
                .Must((value, MaxHeight) => MaxHeight >= value.MinimalHeight)
                .WithMessage("A altura máxima deve ser maior que a altura mínima")
                .When(x => x.MinimalHeight.HasValue && x.MaxHeight.HasValue);
        }
    }
}
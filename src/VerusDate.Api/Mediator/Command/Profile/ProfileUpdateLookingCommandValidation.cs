using FluentValidation;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdateLookingCommandValidation : AbstractValidator<ProfileUpdateLookingCommand>
    {
        public ProfileUpdateLookingCommandValidation()
        {
            RuleFor(x => x.Looking.Intent)
               .NotEmpty();

            RuleFor(x => x.Looking.Distance)
               .NotEmpty()
               .GreaterThanOrEqualTo(0.5)
               .LessThanOrEqualTo(100);

            RuleFor(x => x.Looking.MinimalAge)
                .NotEmpty()
                .GreaterThanOrEqualTo(18);

            RuleFor(x => x.Looking.MaxAge)
                .NotEmpty()
                .LessThanOrEqualTo(120);

            RuleFor(x => x.Looking.MinimalAge)
                .Must((value, MinimalAge) => (byte)MinimalAge <= (byte)value.Looking.MaxAge)
                .WithMessage("Minimum age must be less than the maximum age");

            RuleFor(x => x.Looking.MaxAge)
                .Must((value, MaxAge) => (byte)MaxAge >= (byte)value.Looking.MinimalAge)
                .WithMessage("Maximum age must be greater than the minimum age");

            RuleFor(x => x.Looking.MinimalHeight)
                .Must((value, MinimalHeight) => (byte)MinimalHeight <= (byte)value.Looking.MaxHeight)
                .WithMessage("Minimum height must be less than the maximum height")
                .When(x => x.Looking.MinimalHeight.HasValue && x.Looking.MaxHeight.HasValue);

            RuleFor(x => x.Looking.MaxHeight)
                .Must((value, MaxHeight) => (byte)MaxHeight >= (byte)value.Looking.MinimalHeight)
                .WithMessage("Maximum height must be greater than the minimum height")
                .When(x => x.Looking.MinimalHeight.HasValue && x.Looking.MaxHeight.HasValue);
        }
    }
}
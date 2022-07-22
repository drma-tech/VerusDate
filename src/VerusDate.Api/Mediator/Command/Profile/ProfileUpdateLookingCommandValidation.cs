using FluentValidation;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdateLookingCommandValidation : AbstractValidator<ProfileUpdateLookingCommand>
    {
        public ProfileUpdateLookingCommandValidation()
        {
            RuleFor(x => x.Preference.Intentions)
               .NotEmpty();

            RuleFor(x => x.Preference.MinimalAge)
                .NotEmpty()
                .GreaterThanOrEqualTo(18);

            RuleFor(x => x.Preference.MaxAge)
                .NotEmpty()
                .LessThanOrEqualTo(120);

            RuleFor(x => x.Preference.MinimalAge)
                .Must((value, MinimalAge) => (byte)MinimalAge <= (byte)value.Preference.MaxAge)
                .WithMessage("Minimum age must be less than the maximum age");

            RuleFor(x => x.Preference.MaxAge)
                .Must((value, MaxAge) => (byte)MaxAge >= (byte)value.Preference.MinimalAge)
                .WithMessage("Maximum age must be greater than the minimum age");

            RuleFor(x => x.Preference.MinimalHeight)
                .Must((value, MinimalHeight) => (byte)MinimalHeight <= (byte)value.Preference.MaxHeight)
                .WithMessage("Minimum height must be less than the maximum height")
                .When(x => x.Preference.MinimalHeight.HasValue && x.Preference.MaxHeight.HasValue);

            RuleFor(x => x.Preference.MaxHeight)
                .Must((value, MaxHeight) => (byte)MaxHeight >= (byte)value.Preference.MinimalHeight)
                .WithMessage("Maximum height must be greater than the minimum height")
                .When(x => x.Preference.MinimalHeight.HasValue && x.Preference.MaxHeight.HasValue);
        }
    }
}
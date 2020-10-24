using FluentValidation;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Shared.Validation
{
    public class ProfileLookingValidation : AbstractValidator<ProfileLookingVM>
    {
        public ProfileLookingValidation()
        {
            RuleFor(x => x.Intent)
               .NotEmpty();

            RuleFor(x => x.Distance)
               .NotEmpty()
               .GreaterThanOrEqualTo(0.5)
               .LessThanOrEqualTo(100);

            RuleFor(x => x.MinimalAge)
                .NotEmpty()
                .GreaterThanOrEqualTo(18);

            RuleFor(x => x.MaxAge)
                .NotEmpty()
                .LessThanOrEqualTo(120);

            RuleFor(x => x.MinimalAge)
                .Must((value, MinimalAge) => (byte)MinimalAge <= (byte)value.MaxAge)
                .WithMessage("Minimum age must be less than the maximum age");

            RuleFor(x => x.MaxAge)
                .Must((value, MaxAge) => (byte)MaxAge >= (byte)value.MinimalAge)
                .WithMessage("Maximum age must be greater than the minimum age");

            RuleFor(x => x.MinimalHeight)
                .Must((value, MinimalHeight) => (byte)MinimalHeight <= (byte)value.MaxHeight)
                .WithMessage("Minimum height must be less than the maximum height")
                .When(x => x.MinimalHeight.HasValue && x.MaxHeight.HasValue);

            RuleFor(x => x.MaxHeight)
                .Must((value, MaxHeight) => (byte)MaxHeight >= (byte)value.MinimalHeight)
                .WithMessage("Maximum height must be greater than the minimum height")
                .When(x => x.MinimalHeight.HasValue && x.MaxHeight.HasValue);
        }
    }
}
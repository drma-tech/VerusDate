using FluentValidation;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Shared.Validation
{
    public class EventValidation : AbstractValidator<EventVM>
    {
        public EventValidation()
        {
            RuleFor(x => x.DtStart)
                .NotEmpty();

            RuleFor(x => x.DtEnd)
                .NotEmpty();

            RuleFor(x => x.EventType)
                .NotEmpty();

            RuleFor(x => x.CountryName)
               .NotEmpty();

            RuleFor(x => x.State)
               .NotEmpty();

            RuleFor(x => x.City)
               .NotEmpty();

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

            RuleFor(x => x.Intent)
               .NotEmpty();

            RuleFor(x => x.SexualOrientation)
               .NotEmpty();
        }
    }
}
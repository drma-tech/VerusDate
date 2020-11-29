using FluentValidation;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Shared.Validation
{
    public class TicketValidation : AbstractValidator<TicketVM>
    {
        public TicketValidation()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);
        }
    }
}
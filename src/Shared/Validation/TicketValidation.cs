using FluentValidation;
using VerusDate.Shared.Model;

namespace VerusDate.Shared.Validation
{
    public class TicketValidation : AbstractValidator<Ticket>
    {
        public TicketValidation()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);
        }
    }
}
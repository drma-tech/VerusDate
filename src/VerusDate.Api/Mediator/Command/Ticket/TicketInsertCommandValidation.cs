using FluentValidation;
using VerusDate.Api.Mediator.Command.Ticket;

namespace VerusDate.Shared.Validation
{
    public class TicketInsertCommandValidation : AbstractValidator<TicketInsertCommand>
    {
        public TicketInsertCommandValidation()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(512);
        }
    }
}
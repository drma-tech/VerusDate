using FluentValidation;

namespace VerusDate.Api.Mediator.Command.Support
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
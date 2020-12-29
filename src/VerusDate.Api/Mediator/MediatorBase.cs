using MediatR;

namespace VerusDate.Api.Mediator
{
    public class MediatorQuery<T> : IRequest<T>
    {
        public string IdLoggedUser { get; set; }
    }
}
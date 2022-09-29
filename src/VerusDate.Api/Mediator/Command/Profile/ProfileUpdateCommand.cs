using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdateCommand : ProfileModel, IRequest<ProfileModel>
    { }

    public class ProfileUpdateHandler : IRequestHandler<ProfileUpdateCommand, ProfileModel>
    {
        private readonly IRepository _repo;

        public ProfileUpdateHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProfileModel> Handle(ProfileUpdateCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<ProfileModel>(request.Id, request.Key, cancellationToken);

            //if (obj.DtUpdate != null) //terceira vez que atualiza
            //{
            //    obj.Gamification.RemoveXP(100);
            //}

            if (obj != null)
            {
                obj.UpdateData(request);
                return await _repo.Update(obj, cancellationToken);
            }
            else //todo: revisar isso aqui
            {
                return await _repo.Add(request, cancellationToken);
            }
        }
    }
}
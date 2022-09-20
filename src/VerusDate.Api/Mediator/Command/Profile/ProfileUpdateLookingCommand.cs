using MediatR;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdateLookingCommand : ProfileModel, IRequest<bool>
    { }

    public class ProfileLookingAddHandler : IRequestHandler<ProfileUpdateLookingCommand, bool>
    {
        private readonly IRepository _repo;

        public ProfileLookingAddHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(ProfileUpdateLookingCommand request, CancellationToken cancellationToken)
        {
            //TODO: colocar id e key nos parametros e só passar o objeto preference

            var operations = new List<PatchOperation> {
                PatchOperation.Set("/preference", request.Preference),
                PatchOperation.Add("/dtUpdate", DateTime.UtcNow)
            };

            return await _repo.PatchItem<ProfileModel>(request.Id, request.Key, operations, cancellationToken);
        }
    }
}
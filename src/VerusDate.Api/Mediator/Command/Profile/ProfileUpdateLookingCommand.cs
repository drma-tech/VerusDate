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
    public class ProfileUpdateLookingCommand : ProfileModel, IRequest<ProfileModel>
    { }

    public class ProfileLookingAddHandler : IRequestHandler<ProfileUpdateLookingCommand, ProfileModel>
    {
        private readonly IRepository _repo;

        public ProfileLookingAddHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProfileModel> Handle(ProfileUpdateLookingCommand request, CancellationToken cancellationToken)
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
﻿using MediatR;
using Microsoft.Azure.Cosmos;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdateCommand : ProfileModel, IRequest<ProfileModel> { }

    public class ProfileUpdateHandler : IRequestHandler<ProfileUpdateCommand, ProfileModel>
    {
        private readonly IRepository _repo;

        public ProfileUpdateHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProfileModel> Handle(ProfileUpdateCommand request, CancellationToken cancellationToken)
        {
            //await _gamificationApp.RemoveXP(request.Id, EventRemoveXP.UpdateProfile, cancellationToken);

            var obj = await _repo.Get<ProfileModel>(request.Id, new PartitionKey(request.Key), cancellationToken);

            obj.UpdateProfile(request.Basic, request.Bio, request.Lifestyle, request.Interest);

            return await _repo.Update(obj, cancellationToken);
        }
    }
}
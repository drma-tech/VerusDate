using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VerusDate.Server.App;
using VerusDate.Server.Core.Interface;
using VerusDate.Server.Data.Repository;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.Seed;

namespace VerusDate.Server.Test.App
{
    public class ProfileAppTest
    {
        private readonly IRepository _repo;
        private IProfileApp _app;

        public ProfileAppTest()
        {
            var settings = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("ConnectionStrings:SQL", ""),
            };

            var builder = new ConfigurationBuilder().AddInMemoryCollection(settings);
            var _config = builder.Build();

            _repo = new RepositoryDapper(_config);
        }

        [SetUp]
        public void Setup()
        {
            _app = new ProfileApp(_repo);
        }

        [Test]
        public async Task ProfileApp_AddProfile_ShouldSaveCorrect()
        {
            try
            {
                var obj = ProfileSeed.GetProfileVM();

                _repo.BeginTransaction();

                await _app.Add(obj);

                var result = await _app.GetUser(obj.Id);

                result.Should().NotBeNull();
                result.Should().BeEquivalentTo(obj);

                result.DtInsert.Should().BeAfter(DateTimeOffset.MinValue);
                result.DtUpdate.Should().BeNull();
                result.DtTopList.Should().BeAfter(DateTimeOffset.MinValue);
                result.DtLastLogin.Should().BeAfter(DateTimeOffset.MinValue);
            }
            finally
            {
                _repo.Rollback();
            }
        }

        [Test]
        public async Task ProfileApp_UpdateProfile_ShouldSaveCorrect()
        {
            try
            {
                _repo.BeginTransaction();

                var obj = ProfileSeed.GetProfileVM();
                await _app.Add(obj);

                var obj2 = ProfileSeed.GetProfileVM(obj.Id);

                //campos carregados no app de insert
                obj2.DtInsert = obj.DtInsert;
                obj2.DtTopList = obj.DtTopList;
                obj2.DtLastLogin = obj.DtLastLogin;

                await _app.Update(obj2);

                var result = await _app.GetUser(obj2.Id);

                result.Should().NotBeNull();
                result.Should().BeEquivalentTo(obj2);

                result.DtInsert.Should().Be(obj2.DtInsert);
                result.DtUpdate.Should().NotBeNull();
                result.DtTopList.Should().Be(obj2.DtTopList);
                result.DtLastLogin.Should().Be(obj2.DtLastLogin);
            }
            finally
            {
                _repo.Rollback();
            }
        }

        [Test]
        public async Task ProfileApp_AddProfileLooking_ShouldSaveCorrect()
        {
            try
            {
                var obj = ProfileSeed.GetProfileLookingVM();

                _repo.BeginTransaction();

                await _app.Add(obj);

                var result = await _app.Get(obj.Id);

                result.Should().NotBeNull();
                result.Should().BeEquivalentTo(obj);
            }
            finally
            {
                _repo.Rollback();
            }
        }

        [Test]
        public async Task ProfileApp_UpdateProfileLooking_ShouldSaveCorrect()
        {
            try
            {
                _repo.BeginTransaction();

                var obj = ProfileSeed.GetProfileLookingVM();
                await _app.Add(obj);

                var obj2 = ProfileSeed.GetProfileLookingVM(obj.Id);
                await _app.Update(obj2);

                var result = await _app.Get(obj2.Id);

                result.Should().NotBeNull();
                result.Should().BeEquivalentTo(obj2);
            }
            finally
            {
                _repo.Rollback();
            }
        }

        [Test]
        public async Task ProfileApp_GetView_ShouldNotShowSensitiveData()
        {
            try
            {
                _repo.BeginTransaction();

                var obj = ProfileSeed.GetProfileVM(view: true);
                await _app.Add(obj);

                //para comparar corretamente com os campos que não devem vir na query
                obj.Longitude = null;
                obj.Latitude = null;
                obj.DtInsert = null;
                obj.DtUpdate = null;
                obj.DtTopList = null;
                obj.DtLastLogin = null;

                var result = await _app.GetView(obj.Id, obj.Id);

                result.Should().NotBeNull();
                result.Should().BeEquivalentTo(obj);
                result.Longitude.Should().BeNull();
                result.Latitude.Should().BeNull();
                result.DtInsert.Should().BeNull();
                result.DtUpdate.Should().BeNull();
                result.DtTopList.Should().BeNull();
                result.DtLastLogin.Should().BeNull();
            }
            finally
            {
                _repo.Rollback();
            }
        }
    }
}
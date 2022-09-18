using FluentValidation;
using System;
using VerusDate.Shared.Enum;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdateCommandValidation : AbstractValidator<ProfileUpdateCommand>
    {
        public ProfileUpdateCommandValidation()
        {
            //BASIC

            RuleFor(x => x.Modality)
                .NotEmpty();

            RuleFor(x => x.NickName)
                .NotEmpty()
                .MaximumLength(20)
                .WithName(Shared.Resources.Model.ProfileBasicModel.NickName_Name);

            RuleFor(x => x.Description)
                .NotEmpty().When(x => x.Modality == Shared.Enum.Modality.Matchmaker)
                .MaximumLength(512)
                .WithName(Shared.Resources.Model.ProfileBasicModel.Description_Name);

            RuleFor(x => x.Location)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBasicModel.Location_Name);

            RuleFor(x => x.CurrentSituation)
                .NotEmpty().When(x => x.Modality == Shared.Enum.Modality.Matchmaker)
                .WithName(Shared.Resources.Model.ProfileBasicModel.CurrentSituation_Name);

            RuleFor(x => x.Intentions)
                .NotEmpty()
                .Must((value) => value.Count <= 2)
                .WithMessage("Escolha até no máximo duas intenções")
                .WithName(Shared.Resources.Model.ProfileBasicModel.Intentions_Name);

            RuleFor(x => x.BiologicalSex)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBasicModel.BiologicalSex_Name);

            RuleFor(x => x.GenderIdentity)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBasicModel.GenderIdentity_Name);

            RuleFor(x => x.SexualOrientation)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBasicModel.SexualOrientation_Name);

            RuleFor(x => x.Languages)
                .NotEmpty()
                .Must((value) => value.Count <= 5)
                .WithMessage("Escolha até no máximo cinco idiomas")
                .WithName(Shared.Resources.Model.ProfileBasicModel.Languages_Name);

            //BIO

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow.AddYears(-18).Date).WithMessage("Você deve ter 18 ou mais para se registrar");

            RuleFor(x => x.RaceCategory)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBioModel.RaceCategory_Name);

            RuleFor(x => x.Height)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBioModel.Height_Name);

            RuleFor(x => x.BodyMass)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBioModel.BodyMass_Name);

            //LIFESTYLE

            RuleFor(x => x.Drink)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.Drink_Name);

            RuleFor(x => x.Smoke)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.Smoke_Name);

            RuleFor(x => x.Diet)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.Diet_Name);

            RuleFor(x => x.Religion)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.Religion_Name);

            RuleFor(x => x.HaveChildren)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.HaveChildren_Name);

            RuleFor(x => x.WantChildren)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.WantChildren_Name);

            RuleFor(x => x.EducationLevel)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.EducationLevel_Name);

            RuleFor(x => x.CareerCluster)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.CareerCluster_Name);

            RuleFor(x => x.TravelFrequency)
                .NotEmpty();

            //RuleFor(x => x.Lifestyle.MoneyPersonality)
            //    .NotEmpty();

            //MTBI = OPCIONAL - TEM QUE FAZER TESTE

            //RuleFor(x => x.Lifestyle.RelationshipPersonality)
            //   .NotEmpty();

            //INTERESSES

            RuleFor(x => x.Food)
               .Must((value) => value == null || value.Count <= 3)
               .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Vacation)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Sports)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.LeisureActivities)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.MusicGenre)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.MovieGenre)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.TVGenre)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.ReadingGenre)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");
        }
    }
}
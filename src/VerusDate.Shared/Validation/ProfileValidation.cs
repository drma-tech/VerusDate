using FluentValidation;
using System;
using System.Linq;
using VerusDate.Shared.Model;

namespace VerusDate.Shared.Validation
{
    public class ProfileValidation : AbstractValidator<ProfileModel>
    {
        public ProfileValidation()
        {
            RuleSet("BASIC", () =>
            {
                RuleFor(x => x.Modality)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileBasicModel.Modality_Name);

                RuleFor(x => x.NickName)
                    .NotEmpty()
                    .MaximumLength(20)
                    .WithName(Resources.Model.ProfileBasicModel.NickName_Name);

                RuleFor(x => x.Description)
                    .NotEmpty().When(x => x.Modality == Enum.Modality.Matchmaker)
                    .MaximumLength(512)
                    .WithName(Resources.Model.ProfileBasicModel.Description_Name);

                RuleFor(x => x.Location)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileBasicModel.Location_Name);

                RuleFor(x => x.CurrentSituation)
                    .NotEmpty().When(x => x.Modality == Enum.Modality.Matchmaker)
                    .WithName(Resources.Model.ProfileBasicModel.CurrentSituation_Name);

                RuleFor(x => x.Intentions)
                    .NotEmpty()
                    .Must((value) => value.Count <= 2)
                    .WithMessage("Escolha até no máximo duas intenções")
                    .WithName(Resources.Model.ProfileBasicModel.Intentions_Name);

                RuleFor(x => x.BiologicalSex)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileBasicModel.BiologicalSex_Name);

                RuleFor(x => x.GenderIdentity)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileBasicModel.GenderIdentity_Name);

                RuleFor(x => x.SexualOrientation)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileBasicModel.SexualOrientation_Name);

                RuleFor(x => x.Languages)
                    .NotEmpty()
                    .Must((value) => value.Count <= 5)
                    .WithMessage("Escolha até no máximo cinco idiomas")
                    .WithName(Resources.Model.ProfileBasicModel.Languages_Name);
            });

            RuleSet("BIO", () =>
            {
                RuleFor(x => x.BirthDate)
                    .NotEmpty()
                    .LessThanOrEqualTo(DateTime.UtcNow.AddYears(-18).Date).WithMessage("Você deve ter 18 ou mais para se registrar");

                RuleFor(x => x.RaceCategory)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileBioModel.RaceCategory_Name);

                RuleFor(x => x.Height)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileBioModel.Height_Name);

                RuleFor(x => x.BodyMass)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileBioModel.BodyMass_Name);
            });

            RuleSet("LIFESTYLE", () =>
            {
                RuleFor(x => x.Drink)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileLifestyleModel.Drink_Name);

                RuleFor(x => x.Smoke)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileLifestyleModel.Smoke_Name);

                RuleFor(x => x.Diet)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileLifestyleModel.Diet_Name);

                RuleFor(x => x.Religion)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileLifestyleModel.Religion_Name);

                RuleFor(x => x.HaveChildren)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileLifestyleModel.HaveChildren_Name);

                RuleFor(x => x.WantChildren)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileLifestyleModel.WantChildren_Name);

                RuleFor(x => x.EducationLevel)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileLifestyleModel.EducationLevel_Name);

                RuleFor(x => x.CareerCluster)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileLifestyleModel.CareerCluster_Name);

                RuleFor(x => x.TravelFrequency)
                    .NotEmpty()
                    .WithName(Resources.Model.ProfileLifestyleModel.TravelFrequency_Name);
            });

            RuleSet("PERSONALITY", () =>
            {
                //none here
            });

            RuleSet("INTEREST", () =>
            {
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
            });

            RuleSet("MYRELATIONSHIP", () =>
            {
                RuleFor(x => x.Partners)
                    .Must((value) => value != null && value.Count > 0).When(x => x.Modality == Enum.Modality.RelationshipAnalysis)
                    .WithMessage("Você deve convidar seu parceiro(a) ou aceitar o convite recebido");
            });
        }
    }
}
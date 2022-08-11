using FluentValidation;
using System;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileValidation : AbstractValidator<ProfileModel>
    {
        public ProfileValidation()
        {
            //BASIC

            RuleFor(x => x.Basic.NickName)
               .NotEmpty()
               .MaximumLength(20)
               .WithName(Shared.Resources.Model.ProfileBasicModel.NickName_Name);

            RuleFor(x => x.Basic.Description)
                .NotEmpty()
                .MaximumLength(512)
                .WithName(Shared.Resources.Model.ProfileBasicModel.Description_Name);

            RuleFor(x => x.Basic.Location)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBasicModel.Location_Name);

            RuleFor(x => x.Basic.Longitude)
                .NotEmpty();

            RuleFor(x => x.Basic.Latitude)
                .NotEmpty();

            RuleFor(x => x.Basic.CurrentSituation)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBasicModel.CurrentSituation_Name);

            RuleFor(x => x.Basic.Intentions)
                .NotEmpty()
                .Must((value) => value.Count <= 2)
                .WithMessage("Escolha até no máximo duas intenções")
                .WithName(Shared.Resources.Model.ProfileBasicModel.Intentions_Name);

            RuleFor(x => x.Basic.BiologicalSex)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBasicModel.BiologicalSex_Name);

            RuleFor(x => x.Basic.GenderIdentity)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBasicModel.GenderIdentity_Name);

            RuleFor(x => x.Basic.SexualOrientation)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBasicModel.SexualOrientation_Name);

            RuleFor(x => x.Basic.Languages)
                .NotEmpty()
                .Must((value) => value.Count <= 5)
                .WithMessage("Escolha até no máximo cinco idiomas")
                .WithName(Shared.Resources.Model.ProfileBasicModel.Languages_Name);

            //BIO

            RuleFor(x => x.Bio.BirthDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow.AddYears(-18).Date).WithMessage("Você deve ter 18 ou mais para se registrar");

            RuleFor(x => x.Bio.RaceCategory)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBioModel.RaceCategory_Name);

            RuleFor(x => x.Bio.Height)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBioModel.Height_Name);

            RuleFor(x => x.Bio.BodyMass)
                .NotEmpty()
                .WithName(Shared.Resources.Model.ProfileBioModel.BodyMass_Name);

            //LIFESTYLE

            RuleFor(x => x.Lifestyle.Drink)
                .NotEmpty()
                .When(w => w.Basic.Intentions.IsLongTerm())
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.Drink_Name);

            RuleFor(x => x.Lifestyle.Smoke)
                .NotEmpty()
                .When(w => w.Basic.Intentions.IsLongTerm())
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.Smoke_Name);

            RuleFor(x => x.Lifestyle.Diet)
                .NotEmpty()
                .When(w => w.Basic.Intentions.IsLongTerm())
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.Diet_Name);

            RuleFor(x => x.Lifestyle.Religion)
                .NotEmpty()
                .When(w => w.Basic.Intentions.IsLongTerm())
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.Religion_Name);

            RuleFor(x => x.Lifestyle.HaveChildren)
                .NotEmpty()
                .When(w => w.Basic.Intentions.IsLongTerm())
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.HaveChildren_Name);

            RuleFor(x => x.Lifestyle.WantChildren)
                .NotEmpty()
                .When(w => w.Basic.Intentions.IsLongTerm())
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.WantChildren_Name);

            RuleFor(x => x.Lifestyle.EducationLevel)
                .NotEmpty()
                .When(w => w.Basic.Intentions.IsLongTerm())
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.EducationLevel_Name);

            RuleFor(x => x.Lifestyle.CareerCluster)
                .NotEmpty()
                .When(w => w.Basic.Intentions.IsLongTerm())
                .WithName(Shared.Resources.Model.ProfileLifestyleModel.CareerCluster_Name);

            //PERSONALIDADES

            //RuleFor(x => x.Lifestyle.MoneyPersonality)
            //    .NotEmpty()
            //    .When(w => w.Basic.Intentions.IsLongTerm())
            //    .WithName(Shared.Resources.Model.ProfileLifestyleModel.MoneyPersonality_Name);

            //RuleFor(x => x.Lifestyle.SplitTheBill)
            //    .NotEmpty()
            //    .When(w => w.Basic.Intentions.IsLongTerm())
            //    .WithName(Shared.Resources.Model.ProfileLifestyleModel.SplitTheBill_Name);

            //RuleFor(x => x.Lifestyle.RelationshipPersonality)
            //    .NotEmpty()
            //    .When(w => w.Basic.Intentions.IsLongTerm())
            //    .WithName(Shared.Resources.Model.ProfileLifestyleModel.RelationshipPersonality_Name);

            //RuleFor(x => x.Lifestyle.LoveLanguage)
            //    .NotEmpty()
            //    .When(w => w.Basic.Intentions.IsLongTerm())
            //    .WithName(Shared.Resources.Model.ProfileLifestyleModel.LoveLanguage_Name);

            //RuleFor(x => x.Lifestyle.SexPersonality)
            //    .NotEmpty()
            //    .When(w => w.Basic.Intentions.IsLongTerm())
            //    .WithName(Shared.Resources.Model.ProfileLifestyleModel.SexPersonality_Name);

            //INTERESSES

            RuleFor(x => x.Interest.Food)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Interest.Vacation)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Interest.Sports)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Interest.LeisureActivities)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Interest.MusicGenre)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Interest.MovieGenre)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Interest.TVGenre)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Interest.ReadingGenre)
                .Must((value) => value == null || value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");
        }
    }
}
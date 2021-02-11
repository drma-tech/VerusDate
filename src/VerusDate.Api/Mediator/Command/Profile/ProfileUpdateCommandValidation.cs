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

            RuleFor(x => x.Basic.NickName)
               .NotEmpty()
               .MaximumLength(20);

            RuleFor(x => x.Basic.Description)
                .NotEmpty()
                .MaximumLength(512);

            RuleFor(x => x.Basic.Location)
                .NotEmpty();

            RuleFor(x => x.Basic.Longitude)
                .NotEmpty();

            RuleFor(x => x.Basic.Latitude)
                .NotEmpty();

            RuleFor(x => x.Basic.MaritalStatus)
                .NotEmpty();

            RuleFor(x => x.Basic.Intent)
                .NotEmpty()
                .Must((value) => value.Count <= 2)
                .WithMessage("Escolha até no máximo duas intenções");

            RuleFor(x => x.Basic.BiologicalSex)
                .NotEmpty();

            RuleFor(x => x.Basic.GenderIdentity)
                .NotEmpty();

            RuleFor(x => x.Basic.SexualOrientation)
                .NotEmpty();

            RuleFor(x => x.Basic.Languages)
               .NotEmpty()
               .Must((value) => value.Count <= 5)
               .WithMessage("Escolha até no máximo cinco idiomas");

            //BIO

            RuleFor(x => x.Bio.BirthDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow.AddYears(-18).Date).WithMessage("Você deve ter 18 ou mais para se registrar");

            RuleFor(x => x.Bio.RaceCategory)
                .NotEmpty();

            RuleFor(x => x.Bio.Height)
                .NotEmpty();

            RuleFor(x => x.Bio.BodyMass)
                .NotEmpty();

            //LIFESTYLE

            RuleFor(x => x.Lifestyle.Drink)
                .NotEmpty()
                .When(w => w.Basic.Intent.IsLongTerm());

            RuleFor(x => x.Lifestyle.Smoke)
                .NotEmpty()
                .When(w => w.Basic.Intent.IsLongTerm());

            RuleFor(x => x.Lifestyle.Diet)
                .NotEmpty()
                .When(w => w.Basic.Intent.IsLongTerm());

            RuleFor(x => x.Lifestyle.HaveChildren)
                .NotEmpty()
                .When(w => w.Basic.Intent.IsLongTerm());

            RuleFor(x => x.Lifestyle.WantChildren)
                .NotEmpty()
                .When(w => w.Basic.Intent.IsLongTerm());

            RuleFor(x => x.Lifestyle.EducationLevel)
                .NotEmpty()
                .When(w => w.Basic.Intent.IsLongTerm());

            RuleFor(x => x.Lifestyle.CareerCluster)
               .NotEmpty()
               .When(w => w.Basic.Intent.IsLongTerm());

            RuleFor(x => x.Lifestyle.Religion)
                .NotEmpty()
                .When(w => w.Basic.Intent.IsLongTerm());

            RuleFor(x => x.Lifestyle.MoneyPersonality)
                .NotEmpty()
                .When(w => w.Basic.Intent.IsLongTerm());

            //MTBI = OPCIONAL - TEM QUE FAZER TESTE

            RuleFor(x => x.Lifestyle.RelationshipPersonality)
               .NotEmpty()
               .When(w => w.Basic.Intent.IsLongTerm());

            //INTERESSES

            RuleFor(x => x.Interest.Food)
                .Must((value) => value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Interest.Holidays)
                .Must((value) => value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Interest.Sports)
                .Must((value) => value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Interest.LeisureActivities)
                .Must((value) => value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Interest.Music)
                .Must((value) => value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Interest.Movie)
                .Must((value) => value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");

            RuleFor(x => x.Interest.Reading)
                .Must((value) => value.Count <= 3)
                .WithMessage("Escolha até no máximo três opções");
        }
    }
}
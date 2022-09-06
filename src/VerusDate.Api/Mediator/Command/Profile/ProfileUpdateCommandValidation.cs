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

            RuleFor(x => x.NickName)
               .NotEmpty()
               .MaximumLength(20);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(512);

            RuleFor(x => x.Location)
                .NotEmpty();

            RuleFor(x => x.CurrentSituation)
                .NotEmpty();

            RuleFor(x => x.Intentions)
                .NotEmpty()
                .Must((value) => value.Count <= 2)
                .WithMessage("Escolha até no máximo duas intenções");

            RuleFor(x => x.BiologicalSex)
                .NotEmpty();

            RuleFor(x => x.GenderIdentity)
                .NotEmpty();

            RuleFor(x => x.SexualOrientation)
                .NotEmpty();

            RuleFor(x => x.Languages)
               .NotEmpty()
               .Must((value) => value.Count <= 5)
               .WithMessage("Escolha até no máximo cinco idiomas");

            //BIO

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow.AddYears(-18).Date).WithMessage("Você deve ter 18 ou mais para se registrar");

            RuleFor(x => x.RaceCategory)
                .NotEmpty();

            RuleFor(x => x.Height)
                .NotEmpty();

            RuleFor(x => x.BodyMass)
                .NotEmpty();

            //LIFESTYLE

            RuleFor(x => x.Drink)
                .NotEmpty();

            RuleFor(x => x.Smoke)
                .NotEmpty();

            RuleFor(x => x.Diet)
                .NotEmpty();

            RuleFor(x => x.HaveChildren)
                .NotEmpty();

            RuleFor(x => x.WantChildren)
                .NotEmpty();

            RuleFor(x => x.EducationLevel)
                .NotEmpty();

            RuleFor(x => x.CareerCluster)
               .NotEmpty();

            RuleFor(x => x.Religion)
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
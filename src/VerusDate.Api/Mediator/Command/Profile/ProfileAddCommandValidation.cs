using FluentValidation;
using System;
using VerusDate.Shared.Enum;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileAddCommandValidation : AbstractValidator<ProfileAddCommand>
    {
        public ProfileAddCommandValidation()
        {
            //BASIC

            RuleFor(x => x.Basic.NickName)
               .NotEmpty()
               .MaximumLength(20);

            RuleFor(x => x.Basic.Description)
                .NotEmpty()
                .MaximumLength(512);

            RuleFor(x => x.Basic.Intent)
                .NotEmpty();

            //BIO

            RuleFor(x => x.Bio.BirthDate)
               .NotEmpty()
               .GreaterThanOrEqualTo(DateTime.Now.AddYears(-18)).WithMessage("You must be 18 or older to register");

            //LIFESTYLE

            RuleFor(x => x.Lifestyle.EducationLevel)
                .NotEmpty()
                .When(w => w.Basic.Intent.IsLongTerm());

            RuleFor(x => x.Lifestyle.HaveChildren)
               .NotEmpty()
               .When(w => w.Basic.Intent.IsLongTerm());

            RuleFor(x => x.Lifestyle.WantChildren)
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

            RuleFor(x => x.Lifestyle.RelationshipPersonality)
               .NotEmpty()
               .When(w => w.Basic.Intent.IsLongTerm());

            //OTHERS

            RuleFor(x => x.Looking)
                .Empty();

            RuleFor(x => x.Gamification)
                .Empty();

            RuleFor(x => x.Badge)
                .Empty();

            RuleFor(x => x.Photo)
                .Empty();
        }
    }
}
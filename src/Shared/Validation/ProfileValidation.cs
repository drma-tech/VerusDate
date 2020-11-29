using FluentValidation;
using System;
using VerusDate.Shared.Enum;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Shared.Validation
{
    public class ProfileValidation : AbstractValidator<ProfileVM>
    {
        public ProfileValidation()
        {
            RuleFor(x => x.NickName)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(512);

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now.AddYears(-18)).WithMessage("You must be 18 or older to register");

            RuleFor(x => x.BiologicalSex)
                .NotEmpty();

            RuleFor(x => x.MaritalStatus)
                .NotEmpty();

            RuleFor(x => x.Intent)
                .NotEmpty();

            RuleFor(x => x.Height)
                .NotEmpty();

            RuleFor(x => x.BodyMass)
                .NotEmpty();

            RuleFor(x => x.Drink)
                .NotEmpty();

            RuleFor(x => x.Smoke)
                .NotEmpty();

            RuleFor(x => x.Diet)
               .NotEmpty();

            RuleFor(x => x.RaceCategory)
                .NotEmpty();

            RuleFor(x => x.EducationLevel)
                .NotEmpty()
                .When(w => w.Intent.IsLongTerm());

            RuleFor(x => x.HaveChildren)
               .NotEmpty()
               .When(w => w.Intent.IsLongTerm());

            RuleFor(x => x.WantChildren)
                .NotEmpty()
                .When(w => w.Intent.IsLongTerm());

            RuleFor(x => x.CareerCluster)
               .NotEmpty()
               .When(w => w.Intent.IsLongTerm());

            RuleFor(x => x.Religion)
              .NotEmpty()
              .When(w => w.Intent.IsLongTerm());

            RuleFor(x => x.MoneyPersonality)
                .NotEmpty()
                .When(w => w.Intent.IsLongTerm());

            RuleFor(x => x.RelationshipPersonality)
               .NotEmpty()
               .When(w => w.Intent.IsLongTerm());
        }
    }
}
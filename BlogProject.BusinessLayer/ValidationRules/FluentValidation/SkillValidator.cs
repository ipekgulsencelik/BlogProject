using BlogProject.EntityLayer.Concrete;
using FluentValidation;

namespace BlogProject.BusinessLayer.ValidationRules.FluentValidation
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.SkillName).NotEmpty().WithMessage("Yetenek adı alanı boş bırakılamaz");
            RuleFor(x => x.SkillName).NotNull().WithMessage("Yetenek adı alanı boş bırakılamaz");
            RuleFor(x => x.SkillLevel).NotEmpty().WithMessage("Yetenek seviyesi alanı boş bırakılamaz.");
            RuleFor(x => x.SkillLevel).NotNull().WithMessage("Yetenek seviyesi alanı boş bırakılamaz.");
        }
    }
}
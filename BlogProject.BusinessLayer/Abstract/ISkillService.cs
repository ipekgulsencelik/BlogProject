using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Abstract
{
    public interface ISkillService
    {
        Skill GetByID(int id);
        List<Skill> GetList();
        void SkillAdd(Skill skill);
        void SkillDelete(Skill skill);
        void SkillUpdate(Skill skill);
    }
}
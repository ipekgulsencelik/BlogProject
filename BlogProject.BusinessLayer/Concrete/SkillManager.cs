using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Concrete
{
    public class SkillManager : ISkillService
    {
        private ISkillDAL _skillDAL;

        public SkillManager(ISkillDAL skillDAL)
        {
            _skillDAL = skillDAL;
        }

        public Skill GetByID(int id)
        {
            return _skillDAL.Get(x => x.SkillID == id);
        }

        public List<Skill> GetList()
        {
            return _skillDAL.List();
        }

        public void SkillAdd(Skill skill)
        {
            _skillDAL.Insert(skill);
        }

        public void SkillDelete(Skill skill)
        {
            _skillDAL.Delete(skill);
        }

        public void SkillUpdate(Skill skill)
        {
            _skillDAL.Update(skill);
        }
    }
}
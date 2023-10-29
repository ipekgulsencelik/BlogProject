using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Concrete
{
    public class TalentManager : ITalentService
    {
        private ITalentDAL _talentDAL;

        public TalentManager(ITalentDAL talentDAL)
        {
            _talentDAL = talentDAL;
        }

        public Talent GetByID(int id)
        {
            return _talentDAL.Get(x => x.TalentID == id);
        }

        public List<Talent> GetList()
        {
            return _talentDAL.List();
        }

        public void TalentAdd(Talent talent)
        {
            _talentDAL.Insert(talent);
        }

        public void TalentDelete(Talent talent)
        {
            _talentDAL.Delete(talent);
        }

        public void TalentUpdate(Talent talent)
        {
            _talentDAL.Update(talent);
        }
    }
}
using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Abstract
{
    public interface ITalentService
    {
        List<Talent> GetList();
        Talent GetByID(int id);
        void TalentAdd(Talent talent);
        void TalentDelete(Talent talent);
        void TalentUpdate(Talent talent);
    }
}
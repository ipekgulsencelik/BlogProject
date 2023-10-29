using System.ComponentModel.DataAnnotations;

namespace BlogProject.EntityLayer.Concrete
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }

        [StringLength(100)]
        public string SkillName { get; set; }

        public string SkillDetails { get; set; }

        public byte SkillLevel { get; set; }

        public int? TalentID { get; set; }
        public virtual Talent Talent { get; set; }
    }
}
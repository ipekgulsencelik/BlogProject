using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.EntityLayer.Concrete
{
    public class Talent
    {
        [Key]
        public int TalentID { get; set; }

        [StringLength(100)]
        public string TalentName { get; set; }

        public string TalentDetails { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.EntityLayer.Concrete
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        public string StatusName { get; set; }

        public ICollection<Admin> Admins { get; set; }

        public ICollection<Heading> Headings { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
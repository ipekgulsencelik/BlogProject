using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace BlogProject.EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(200)]
        public string CategoryDescription { get; set; }

        public DateTime CategoryDate { get; set; }

        public int? StatusID { get; set; }
        public virtual Status Status { get; set; }

        public ICollection<Heading> Headings { get; set; }
    }
}
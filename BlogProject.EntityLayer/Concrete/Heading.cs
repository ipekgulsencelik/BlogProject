using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }

        public DateTime HeadingDate { get; set; }

        public int? StatusID { get; set; }
        public virtual Status Status { get; set; }

        public int CategoryID { get; set; } 
        public virtual Category Category { get; set; } 

        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<Content> Contents { get; set; } 
    }
}

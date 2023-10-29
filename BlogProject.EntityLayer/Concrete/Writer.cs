using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }

        [StringLength(50)]
        public string WriterUserName { get; set; }

        [StringLength(50)]
        public string WriterName { get; set; }

        [StringLength(50)]
        public string WriterSurName { get; set; }

        [StringLength(250)]
        public string WriterImage { get; set; }

        [StringLength(250)]
        public string WriterAbout { get; set; }

        public string WriterMail { get; set; }
        public byte[] WriterPasswordHash { get; set; }
        public byte[] WriterPasswordSalt { get; set; }

        [StringLength(50)]
        public string WriterTitle { get; set; }

        public bool WriterStatus { get; set; }
        public string WriterRole { get; set; }

        public ICollection<Heading> Headings { get; set; } 
        public ICollection<Content> Contents { get; set; } 
    }
}
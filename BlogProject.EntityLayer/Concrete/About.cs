using System.ComponentModel.DataAnnotations;

namespace BlogProject.EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }

        [StringLength(500)]
        public string AboutDetails1 { get; set; }

        [StringLength(1000)]
        public string AboutDetails2 { get; set; }

        [StringLength(100)]
        public string AboutImage1 { get; set; }

        [StringLength(100)]
        public string AboutImage2 { get; set; }

        public bool Status { get; set; }
    }
}
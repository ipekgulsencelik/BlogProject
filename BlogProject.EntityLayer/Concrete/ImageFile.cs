using System;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.EntityLayer.Concrete
{
    public class ImageFile
    {
        [Key]
        public int ImageFileID { get; set; }

        [StringLength(100)]
        public string ImageName { get; set; }

        [StringLength(500)]
        public string ImagePath { get; set; }

        public DateTime ImageDate { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace BlogProject.EntityLayer.Concrete
{
    public class ScreenShot
    {
        [Key]
        public int ScreenShotID { get; set; }

        [StringLength(100)]
        public string ImageName { get; set; }

        [StringLength(500)]
        public string ImagePath { get; set; }
    }
}
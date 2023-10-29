using System.ComponentModel.DataAnnotations;

namespace BlogProject.EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(50)]
        public string AdminUserName { get; set; }

        public byte[] AdminMail { get; set; }
        public byte[] AdminPasswordHash { get; set; }
        public byte[] AdminPasswordSalt { get; set; }

        public int? StatusID { get; set; }
        public virtual Status Status { get; set; }

        public int? RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}
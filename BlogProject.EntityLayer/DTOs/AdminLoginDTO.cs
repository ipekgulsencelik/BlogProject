namespace BlogProject.EntityLayer.DTOs
{
    public class AdminLoginDTO
    {
        public string AdminUserName { get; set; }
        public string AdminMail { get; set; }
        public string AdminPassword { get; set; }
        public int AdminRoleID { get; set; }
        public int AdminStatusID { get; set; }
    }
}
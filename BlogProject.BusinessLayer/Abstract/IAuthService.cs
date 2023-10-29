using BlogProject.EntityLayer.DTOs;

namespace BlogProject.BusinessLayer.Abstract
{
    public interface IAuthService
    {
        void AdminRegister(string adminUserName, string adminMail, string password, int adminRole, int status);
        bool AdminLogin(AdminLoginDTO adminLoginDTO);

        void WriterRegister(string writerName, string writerSurName, string writerTitle, string writerAbout, string writerImage, string writerUserName, string writerMail, string password, bool WriterStatus);
        bool WriterLogin(WriterLoginDTO writerLoginDTO);
    }
}
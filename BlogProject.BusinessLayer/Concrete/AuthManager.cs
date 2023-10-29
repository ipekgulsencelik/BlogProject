using BlogProject.BusinessLayer.Abstract;
using BlogProject.BusinessLayer.Utilities.Cryptos.Hashing;
using BlogProject.EntityLayer.Concrete;
using BlogProject.EntityLayer.DTOs;
using System.Text;

namespace BlogProject.BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        IAdminService _adminService;
        IWriterService _writerService;

        public AuthManager(IAdminService adminService, IWriterService writerService)
        {
            _adminService = adminService;
            _writerService = writerService;
        }

        public AuthManager(IAdminService adminService)
        {
            _adminService = adminService;

        }

        public AuthManager(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public bool AdminLogin(AdminLoginDTO adminLoginDTO)
        {
            using (var crypto = new System.Security.Cryptography.HMACSHA512())
            {
                var mailHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(adminLoginDTO.AdminMail));
                var admin = _adminService.GetList();
                foreach (var item in admin)
                {
                    if (HashingHelper.AdminVerifyPasswordHash(adminLoginDTO.AdminMail, adminLoginDTO.AdminPassword, item.AdminMail,
                        item.AdminPasswordHash, item.AdminPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void AdminRegister(string adminUserName, string adminMail, string password, int adminRole, int status)
        {
            byte[] mailHash, passwordHash, passwordSalt;
            HashingHelper.AdminCreatePasswordHash(adminMail, password, out mailHash, out passwordHash, out passwordSalt);
            var admin = new Admin
            {
                AdminUserName = adminUserName,
                AdminMail = mailHash,
                AdminPasswordHash = passwordHash,
                AdminPasswordSalt = passwordSalt,
                RoleID = adminRole,
                StatusID = status
            };
            _adminService.AdminAdd(admin);
        }

        public bool WriterLogin(WriterLoginDTO writerLoginDTO)
        {
            using (var crypto = new System.Security.Cryptography.HMACSHA512())
            {
                //var mailHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(writerLogInDto.WriterMail));
                var writer = _writerService.GetList();
                foreach (var item in writer)
                {
                    if (HashingHelper.WriterVerifyPasswordHash(writerLoginDTO.WriterPassword,
                        item.WriterPasswordHash, item.WriterPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void WriterRegister(string writerName, string writerSurName, string writerTitle, string writerAbout, string writerImage, string writerUserName, string writerMail, string password, bool WriterStatus)
        {
            byte[] mailHash, passwordHash, passwordSalt;
            HashingHelper.WriterCreatePasswordHash(password, out passwordHash, out passwordSalt);
            var writer = new Writer
            {
                WriterName = writerName,
                WriterSurName = writerSurName,
                WriterTitle = writerTitle,
                WriterAbout = writerAbout,
                WriterImage = writerImage,
                WriterUserName = writerUserName,
                WriterMail = writerMail,
                WriterPasswordHash = passwordHash,
                WriterPasswordSalt = passwordSalt,
                WriterStatus = WriterStatus
            };
            _writerService.WriterAdd(writer);
        }
    }
}
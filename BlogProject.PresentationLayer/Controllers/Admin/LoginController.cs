using BlogProject.BusinessLayer.Abstract;
using BlogProject.BusinessLayer.Concrete;
using BlogProject.DataAccessLayer.EntityFramework;
using BlogProject.EntityLayer.DTOs;
using BlogProject.PresentationLayer.Models;
using Newtonsoft.Json;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogProject.PresentationLayer.Controllers.Admin
{
    [AllowAnonymous] 
    public class LoginController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EFAdminDAL()), new WriterManager(new EFWriterDAL()));

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogIn(AdminLoginDTO adminLogInDto)
        {
            var response = Request["g-recaptcha-response"];
            /* const string secret = "6Lc9zzgbAAAAAFBGD3Gb201yvNAX4Tb5LAzlqy0d";*/ //Localhost icin Google Captcha v2


            /*const string secret = "6LewJJEbAAAAAIslbgvowPTE0lZ8Yiwk5-cV6p7s"; *///Localhost icin Google Captcha v3
            const string secret = "6LdF9ZAbAAAAAOq5NKMx8jK2K-O5ISBLXWOwOKI7"; //"6LdF9ZAbAAAAAOq5NKMx8jK2K-O5ISBLXWOwOKI7"; - //Canli Site icin mail ile site adi kayit yaptirilir Google Captcha v3

            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResult>(reply);

            if (authService.AdminLogin(adminLogInDto) && captchaResponse.Success)
            {
                FormsAuthentication.SetAuthCookie(adminLogInDto.AdminMail, false);
                Session["AdminMail"] = adminLogInDto.AdminMail;
                var session = Session["AdminMail"];
                //var adminIdInfo = context.Admins.Where(x => x.AdminMail == session).Select(y => y.AdminId).FirstOrDefault();
                //ViewBag.logIn = adminIdInfo;
                ViewBag.a = session;
                return RedirectToAction("Index", "Statistic");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return View();
            }
            #region Eski Kodlar
            //Context context = new Context(); 
            //var adminUser = context.Admins.FirstOrDefault(x =>
            //    x.AdminMail == admin.AdminMail && x.AdminPassword == admin.AdminPassword);

            //if (adminUser != null)
            //{
            //    FormsAuthentication.SetAuthCookie(adminUser.AdminUserName, false); //Sisteme giriş yapan kişinin form bilgileri buradan alınır. Buradaki false değeri ise, kalıcı bir cookie değerinin olmayacağını belirtir.

            //    Session["AdminMail"] = adminUser.AdminMail; //Oturum yönetimi kodu yazılır. Session içerisinde yazılacak değer; köşeli parantez içerisine(sisteme giriş yapan kullanıcının mail adresi gerekli) yazılır
            //    return RedirectToAction("Index", "AdminCategory");
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
            //return View();
            #endregion
        }

        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        #region Eski Kodlar
        //[HttpPost]
        //public ActionResult WriterLogIn(Writer writer)
        //{
        //    Context context = new Context(); 
        //    var writerUser = context.Writers.FirstOrDefault(x =>
        //        x.WriterMail == writer.WriterMail && x.WriterPasswordSalt == writer.WriterPasswordSalt);

        //    if (writerUser != null)
        //    {
        //        FormsAuthentication.SetAuthCookie(writerUser.WriterMail.ToString(), false); 
        //        Session["WriterMail"] = writerUser.WriterMail; 
        //        return RedirectToAction("MyContent", "WriterPanelContent");
        //    }
        //    else
        //    {
        //        return RedirectToAction("WriterLogin");
        //    }
        //}
        #endregion

        [HttpPost]
        public ActionResult WriterLogIn(WriterLoginDTO writerLoginDTO)
        {
            var response = Request["g-recaptcha-response"];
            /* const string secret = "6Lc9zzgbAAAAAFBGD3Gb201yvNAX4Tb5LAzlqy0d";*/ //Localhost icin Google Captcha v2

            /*const string secret = "6LewJJEbAAAAAIslbgvowPTE0lZ8Yiwk5-cV6p7s"; *///Localhost icin Google Captcha v3
            const string secret = "6LdF9ZAbAAAAAOq5NKMx8jK2K-O5ISBLXWOwOKI7"; //"6LdF9ZAbAAAAAOq5NKMx8jK2K-O5ISBLXWOwOKI7"; - //Canli Site icin mail ile site adi kayit yaptirilir Google Captcha v3
            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResult>(reply);

            if (authService.WriterLogin(writerLoginDTO) && captchaResponse.Success)
            {
                FormsAuthentication.SetAuthCookie(writerLoginDTO.WriterMail, false);
                Session["WriterMail"] = writerLoginDTO.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult WriterLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            //return RedirectToAction("Headings", "Default");
            return RedirectToAction("WriterLogin", "Login");
        }
    }
}
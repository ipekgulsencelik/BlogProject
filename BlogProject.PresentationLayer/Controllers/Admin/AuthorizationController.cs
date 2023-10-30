using BlogProject.BusinessLayer.Abstract;
using BlogProject.BusinessLayer.Concrete;
using BlogProject.DataAccessLayer.EntityFramework;
using BlogProject.EntityLayer.DTOs;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlogProject.PresentationLayer.Controllers.Admin
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EFAdminDAL());
        IAuthService authService = new AuthManager(new AdminManager(new EFAdminDAL()));
        RoleManager roleManager = new RoleManager(new EFRoleDAL());
        StatusManager statusManager = new StatusManager(new EFStatusDAL());

        public ActionResult Index(int? page)
        {
            var adminValues = adminManager.GetList().ToPagedList(page ?? 1, 8);
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> adminRoleValue = (from x in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Description,
                                                       Value = x.RoleID.ToString()
                                                   }).ToList();

            List<SelectListItem> adminStatusValue = (from x in statusManager.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.StatusName,
                                                         Value = x.StatusID.ToString()
                                                     }).ToList();
            ViewBag.valueAdminStatus = adminStatusValue;
            ViewBag.valueAdminRole = adminRoleValue;
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(AdminLoginDTO adminLoginDTO)
        {
            authService.AdminRegister(adminLoginDTO.AdminUserName, adminLoginDTO.AdminMail, adminLoginDTO.AdminPassword,
                adminLoginDTO.AdminRoleID, adminLoginDTO.AdminStatusID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateRole(int id)
        {
            List<SelectListItem> adminRoleValue = (from x in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Description,
                                                       Value = x.RoleID.ToString()
                                                   }).ToList();
            ViewBag.valueAdminRole = adminRoleValue;
            var adminValue = adminManager.GetByID(id);
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult UpdateRole(BlogProject.EntityLayer.Concrete.Admin admin)
        {
            adminManager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var adminValue = adminManager.GetByID(id);
            adminManager.AdminDelete(adminValue);
            return RedirectToAction("Index");
        }

        public ActionResult ChangeAdminStatus(int id)
        {
            var adminValue = adminManager.GetByID(id);

            if (adminValue.StatusID == 2) // Durumu Aktif mi?
            {
                adminValue.StatusID = 1; // Durumu pasif yap
            }
            else
            {
                adminValue.StatusID = 2; // Durumu aktif yap
            }
            adminManager.AdminUpdate(adminValue);
            return RedirectToAction("Index");
        }

        public PartialViewResult AuthorizationPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult UpdateProfile(int id, AdminLoginDTO adminLoginDTO)
        {
            List<SelectListItem> adminStatusValue = (from x in statusManager.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.StatusName,
                                                         Value = x.StatusID.ToString()
                                                     }).ToList();

            List<SelectListItem> adminRoleValue = (from x in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Description,
                                                       Value = x.RoleID.ToString()
                                                   }).ToList();

            //var admin = _adminService.GetList();
            //var adminValue = authService.AdminLogIn(adminLogInDto);
            ViewBag.valueAdminStatus = adminStatusValue;
            ViewBag.valueAdminRole = adminRoleValue;
            var adminValue = adminManager.GetByID(id);
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult UpdateProfile(BlogProject.EntityLayer.Concrete.Admin admin)
        {
            admin.StatusID = 2;
            adminManager.AdminUpdate(admin);

            return RedirectToAction("Index");
        }
    }
}
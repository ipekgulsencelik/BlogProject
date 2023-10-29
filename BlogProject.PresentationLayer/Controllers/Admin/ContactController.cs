using BlogProject.BusinessLayer.Concrete;
using BlogProject.DataAccessLayer.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace BlogProject.PresentationLayer.Controllers.Admin
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EFContactDAL());
        MessageManager messageManager = new MessageManager(new EFMessageDAL());

        public ActionResult Index()
        {
            var contactValues = contactManager.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetByID(id);

            // contactManager.GetByIDAndSetRead(id,true); //<-- Buraya, mail acildiginda IsRead alanina true (okundu) yazacak kod gelecek!!!
            return View(contactValues);
        }

        public PartialViewResult _MessageMenuPartial()
        {
            string session = (string)Session["AdminMail"];

            var contact = contactManager.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = messageManager.GetSendboxList(session).Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = messageManager.GetInboxList(session).Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = messageManager.GetDraftList(session).Count(); 
            ViewBag.draftMail = draftMail;

            var trashMail = messageManager.GetTrashList().Count();
            ViewBag.trashMail = trashMail;

            var readMail = messageManager.GetReadList(session).Count;
            ViewBag.readMail = readMail;

            var unReadMail = messageManager.GetUnReadList(session).Count;
            ViewBag.unReadMail = unReadMail;

            var importantMail = messageManager.GetImportantList(session).Count();
            ViewBag.importantMail = importantMail;

            var spamMail = messageManager.GetSpamList(session).Count();
            ViewBag.spamMail = spamMail;

            return PartialView();
        }

        public PartialViewResult _MessageListPartial()
        {
            return PartialView();
        }

        public PartialViewResult _MessageListFooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult _MessageListFooterButtonPartial()
        {
            return PartialView();
        }

        public ActionResult IsRead(int id) 
        {
            var contactValue = contactManager.GetByID(id);

            if (contactValue.IsRead)
            {
                contactValue.IsRead = false;
            }
            else
            {
                contactValue.IsRead = true;
            }

            contactManager.ContactUpdate(contactValue);
            return RedirectToAction("Index");
        }

        public ActionResult IsImportant(int id) 
        {
            var contactValue = contactManager.GetByID(id);

            if (contactValue.IsImportant)
            {
                contactValue.IsImportant = false;
            }
            else
            {
                contactValue.IsImportant = true;
            }

            contactManager.ContactUpdate(contactValue);
            return RedirectToAction("Index");
        }
    }
}
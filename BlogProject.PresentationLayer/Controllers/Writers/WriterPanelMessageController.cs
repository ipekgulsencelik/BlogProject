﻿using BlogProject.BusinessLayer.Concrete;
using BlogProject.BusinessLayer.ValidationRules.FluentValidation;
using BlogProject.DataAccessLayer.EntityFramework;
using BlogProject.EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BlogProject.PresentationLayer.Controllers.Writers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageDAL());
        MessageValidator messagerValidator = new MessageValidator();

        public ActionResult Inbox(int? page)
        {
            string session = (string)Session["WriterMail"];
            var messageListInbox = messageManager.GetInboxList(session).ToPagedList(page ?? 1, 8); 
            return View(messageListInbox);
        }

        public PartialViewResult _MessageMenuPartial()
        {
            string session = (string)Session["WriterMail"];
            var sendMail = messageManager.GetSendboxList(session).Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = messageManager.GetInboxList(session).Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = messageManager.GetDraftList(session).Count(); //GetListSendbox().Where(m => m.IsDraft == true).Count();
            ViewBag.draftMail = draftMail;

            var trashMail = messageManager.GetTrashList().Count();
            ViewBag.trashMail = trashMail;

            var readMail = messageManager.GetReadList(session).Count;
            ViewBag.readMail = readMail;

            var unReadMail = messageManager.GetUnReadList(session).Count;
            ViewBag.unReadMail = unReadMail;

            var importantMail = messageManager.GetImportantList(session).Count();
            ViewBag.importantMail = importantMail;

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

        public ActionResult Sendbox()
        {
            string session = (string)Session["WriterMail"];
            var messageListSendbox = messageManager.GetSendboxList(session);
            return View(messageListSendbox);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetByID(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult NewMessage(Message message, string menuName)
        {
            ValidationResult results = messagerValidator.Validate(message);
            string session = (string)Session["WriterMail"];

            if (menuName == "send")
            {
                if (results.IsValid)
                {
                    message.SenderMail = session;
                    //message.IsDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAdd(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (menuName == "draft")
            {
                if (results.IsValid)
                {
                    message.SenderMail = session;
                    message.IsDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAdd(message);
                    return RedirectToAction("DraftMessages");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (menuName == "cancel")
            {
                return RedirectToAction("NewMessage");
            }
            return View();
        }

        public ActionResult DeleteMessage(int id) 
        {
            var result = messageManager.GetByID(id);
            if (result.Trash == true)
            {
                result.Trash = false;
            }
            else
            {
                result.Trash = true;
            }
            messageManager.MessageDelete(result);
            return RedirectToAction("Inbox");
        }

        public ActionResult DraftMessages()
        {
            string session = (string)Session["WriterMail"];
            var result = messageManager.IsDraft(session);
            return View(result);
        }

        public ActionResult GetDraftDetails(int id)
        {
            var result = messageManager.GetByID(id);
            return View(result);
        }

        public ActionResult IsRead(int id) 
        {
            var messageValue = messageManager.GetByID(id);

            if (messageValue.IsRead)
            {
                messageValue.IsRead = false;
            }
            else
            {
                messageValue.IsRead = true;
            }

            messageManager.MessageUpdate(messageValue);
            return RedirectToAction("Inbox");
        }

        public ActionResult IsImportant(int id) 
        {
            var messageValue = messageManager.GetByID(id);

            if (messageValue.IsImportant)
            {
                messageValue.IsImportant = false;
            }
            else
            {
                messageValue.IsImportant = true;
            }

            messageManager.MessageUpdate(messageValue);
            return RedirectToAction("Inbox");
        }
    }
}
using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public Message GetByID(int id)
        {
            return _messageDAL.Get(x => x.MessageID == id);
        }

        public List<Message> GetDraftList(string session)
        {
            return _messageDAL.List(x => x.IsDraft == true && x.SenderMail == session);
        }

        public List<Message> GetImportantList(string session)
        {
            return _messageDAL.List(x => x.IsImportant == true && x.ReceiverMail == session);
        }

        public List<Message> GetInboxList(string session)
        {
            return _messageDAL.List(x => x.ReceiverMail == session);
        }

        public List<Message> GetReadList(string session)
        {
            return _messageDAL.List(x => x.IsRead == true && x.ReceiverMail == session);
        }

        public List<Message> GetSendboxList(string session)
        {
            return _messageDAL.List(x => x.SenderMail == session);
        }

        public List<Message> GetSpamList(string session)
        {
            return _messageDAL.List(x => x.IsSpam == true && x.ReceiverMail == session);
        }

        public List<Message> GetTrashList()
        {
            return _messageDAL.List(x => x.Trash == true);
        }

        public List<Message> GetUnReadList(string session)
        {
            return _messageDAL.List(x => x.ReceiverMail == session && x.IsRead == false);
        }

        public List<Message> IsDraft(string session)
        {
            return _messageDAL.List(x => x.IsDraft == true && x.SenderMail == session);
        }

        public void MessageAdd(Message message)
        {
            _messageDAL.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDAL.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDAL.Update(message);
        }
    }
}
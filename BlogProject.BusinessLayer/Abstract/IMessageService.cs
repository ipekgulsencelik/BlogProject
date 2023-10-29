using BlogProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetInboxList(string session);
        List<Message> GetSendboxList(string session);
        List<Message> GetReadList(string session);
        List<Message> GetUnReadList(string session);
        List<Message> IsDraft(string session);
        List<Message> GetDraftList(string session);
        List<Message> GetTrashList();
        List<Message> GetSpamList(string session);
        List<Message> GetImportantList(string session);
        Message GetByID(int id);
        void MessageAdd(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
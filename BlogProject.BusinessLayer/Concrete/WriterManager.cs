using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerDAL;  
        IWriterService _writerService;

        public WriterManager(IWriterDAL writerDAL) 
        {
            _writerDAL = writerDAL;
        }

        public Writer GetByID(int id)
        {
            return _writerDAL.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerDAL.List();
        }

        public List<Writer> GetListByWriterID(int id)
        {
            return _writerDAL.List(x => x.WriterID == id);
        }

        public void WriterAdd(Writer writer)
        {
            //CheckIfWriterExists(writer);
            _writerDAL.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDAL.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDAL.Update(writer);
        }

        //Yazar sifre degistirme islemlerine sonra devam edecegim

        //public void UpdatePassword(string currentPassword, string newPassword, Writer writer)
        //{
        //    /*Sifre Degikligi Islemleri
        //     1- UI katmaninda kullanici mevcut sifresini girer
        //     2- BL katmaninda kullanicinin girdigi sifre ile mevcut sifre dogrulamasi yapilir
        //     3- UI katmaninda kullanicinin girdigi yeni sifre ve yeni sifre tekrari dogrulugu kontrol edilir
        //     4- BL katmaninda bir üst adimdan true dönerse kullanicinin girdigi yeni sifre hashleme islemine tabi tutulur
        //     */

        //    if (CurrentPasswordControl(currentPassword))
        //    {
        //        HashingHelper.WriterCreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

        //        //var writerInfo = GetById(writer.WriterId);
        //        writer.WriterPasswordHash = passwordHash;
        //        writer.WriterPasswordSalt = passwordSalt;
        //        _writerDal.Update(writer);
        //    }
        //}

        //private bool CurrentPasswordControl(string currentPassword)
        //{
        //    using (var crypto = new System.Security.Cryptography.HMACSHA512())
        //    {
        //        //var writer = _writerService.GetList();
        //        //foreach (var item in writer)
        //        //{
        //        //    if (HashingHelper.WriterVerifyPasswordHash(currentPassword, item.WriterPasswordHash, item.WriterPasswordSalt))
        //        //    {
        //        //        return true;
        //        //    }
        //        //}
        //        return false;
        //    }
        //}

        //private void CheckIfWriterExists(Writer writer)
        //{
        //    if (_writerDal.Get(x => x.WriterMail == writer.WriterMail) != null)
        //    {
        //        throw new Exception("Bu kullanıcı daha önce kayıt olmuştur.");
        //    }
        //}
    }
}

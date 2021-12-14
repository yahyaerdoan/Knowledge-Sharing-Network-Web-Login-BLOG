using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }

        public Message GetById(int id)
        {
           return _messageDal.GetById(id);
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        public List<Message> ListAll(Expression<Func<Message, bool>> filter)
        {
           return _messageDal.ListAll(filter);
        }

        public Message GetByFilter(Expression<Func<Message, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int GetByCount(Expression<Func<Message, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetInBoxMessageListByWriterId(int id)
        {
            return _messageDal.GetAllWithMessageByWriterId(id);
        }
    }
}

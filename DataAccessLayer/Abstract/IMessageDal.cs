using System.Collections.Generic;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
        List<Message> GetAllWithMessageByWriterId(int id);
    }
}
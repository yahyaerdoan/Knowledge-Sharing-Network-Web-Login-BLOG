using System.Collections.Generic;
using BusinessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> GetInBoxMessageListByWriterId(int id);
    }
}
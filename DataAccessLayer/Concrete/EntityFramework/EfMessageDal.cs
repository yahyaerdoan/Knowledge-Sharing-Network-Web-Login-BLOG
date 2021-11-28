using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public List<Message> GetAllWithMessageByWriterId(int id)
        {
            using var c = new WebLogContext();
            {
                return c.Messages.Include(x => x.MessageOfSender)
                    .Where(x => x.MessageReceiverId == id).ToList();
            }
        }
    }
}
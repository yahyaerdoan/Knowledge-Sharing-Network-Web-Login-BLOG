using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
    }
}
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
    }
}

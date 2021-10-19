using EntityLayer.Concrete;
using System.Collections.Generic;
using BusinessLayer.Repositories.Abstract;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
       

        //List<Comment> GetAllWithCategory();
        List<Comment> GetListCommentById(int id);
    }
}

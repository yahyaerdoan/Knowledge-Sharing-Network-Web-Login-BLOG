using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void Add(Comment comment);
        void Delete(Comment comment);
        void Update(Comment comment);
        Comment GetById(int id);
        List<Comment> GetAll();

        //List<Comment> GetAllWithCategory();
        List<Comment> GetListCommentById(int id);
    }
}

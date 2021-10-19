using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        readonly ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void Delete(Comment comment)
        {
            throw new System.NotImplementedException();
        }

        public List<Comment> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Comment> ListAll(Expression<Func<Comment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Comment> GetListCommentById(int id)
        {
            return _commentDal.ListAll(x => x.BlogId == id);
            
        }

        public void Update(Comment comment)
        {
            throw new System.NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Add(Notification notification)
        {
            _notificationDal.Add(notification);
        }

        public void Delete(Notification notification)
        {
            _notificationDal.Delete(notification);
        }

        public void Update(Notification notification)
        {
            _notificationDal.Update(notification);
        }

        public Notification GetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public List<Notification> ListAll(Expression<Func<Notification, bool>> filter)
        {
            return _notificationDal.ListAll(filter);
        }

        public Notification GetByFilter(Expression<Func<Notification, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int GetByCount(Expression<Func<Notification, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}

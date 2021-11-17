using BusinessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
    }
}

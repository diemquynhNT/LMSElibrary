using NotificationService.Model;

namespace NotificationService.Service
{
    public interface INotificationServices
    {
        public List<Notifications> GetAllNotificationForUser(string id);
        public Task<Notifications> AddNotification(Notifications noti,string idSubject,string idClass,string idSender);
        public Task<Notifications> UpdateUser(Notifications noti);
        public Task<bool> DeleteNotification(string id);
    }
}

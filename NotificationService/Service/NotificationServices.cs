using Microsoft.EntityFrameworkCore;
using NotificationService.Data;
using NotificationService.Model;
using System.Net.Http;

namespace NotificationService.Service
{
    public class NotificationServices : INotificationServices
    {
        private readonly MyDbContext _context;
        public NotificationServices(MyDbContext context)
        {
            this._context = context;
        }

        public async Task<Notifications> AddNotification(Notifications noti, string idSubject, string idClass,string idSender)
        {
            Random rd=new Random();
            noti.IdNotification="TB"+rd.Next(1,9)+rd.Next(10,99);
            noti.DateCreate=DateTime.Now;
            noti.IdSubject=idSubject;
            noti.IdClass=idClass;
            noti.IdSender = idSender;
            noti.Status = false;
            _context.notifications.Add(noti);
            _context.SaveChanges();
            return noti;
        }
    

        public async Task<bool> DeleteNotification(string id)
        {
            var noti = await _context.notifications.Where(n=>n.IdNotification==id).FirstOrDefaultAsync();
            if (noti == null)
                return false;

            _context.notifications.Remove(noti);
            await _context.SaveChangesAsync();

            return true;
        }

        public List<Notifications> GetAllNotificationForUser(string id)
        {
           return _context.notifications.Where(n=>n.Idreceiver == id).ToList();
        }

        public async Task<Notifications> UpdateUser(Notifications noti)
        {
            _context.notifications.Update(noti);
            await _context.SaveChangesAsync();
            return noti;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace NotificationService.Dto
{
    public class NotificationModel
    {
     
        public string ContentNotification { get; set; }
        public string TitleNotification { get; set; }
        public List<string> Idreceiver { get; set; }
    }
}

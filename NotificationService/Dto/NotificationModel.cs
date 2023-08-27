using System.ComponentModel.DataAnnotations;

namespace NotificationService.Dto
{
    public class NotificationModel
    {
     
        public string ContentNotification { get; set; }
        public string TitleNotification { get; set; }
        public string? Idreceiver { get; set; }
    }
}

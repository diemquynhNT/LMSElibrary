using System.ComponentModel.DataAnnotations;

namespace NotificationService.Model
{
    public class Notifications
    {
        [Key]
        public string IdNotification { get; set; }
        [Required]
        [MaxLength(100)]
        public string TitleNotification { get; set; }
        [Required]
        public string ContentNotification { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }

        public string? IdSubject { get; set; }
        public string? IdClass { get; set; }
        [Required]
        public string IdSender { get; set; }
        [Required]
        public bool Status { get; set; }
        public string? Idreceiver { get; set; }
    }
}

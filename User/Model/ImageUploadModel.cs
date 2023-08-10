using System.ComponentModel.DataAnnotations;

namespace UserService.Model
{
    public class ImageUploadModel
    {
        public IFormFile Users { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nameus { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string Numphone { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ElectroMVC.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Useremail { get; set; }
        [Required]
        public string? UserRote { get; set; }

    }
}

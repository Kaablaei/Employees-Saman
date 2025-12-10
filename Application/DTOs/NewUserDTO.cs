using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public record NewUserDTO
    {
        [Required]
        [MaxLength(200)]
        public string? UserName { get; set; }

        [Required]
        [PasswordPropertyText]
        public string? Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record AddUserDTO
    {
        [Required]
        [MaxLength(200)]
        public string? UserName { get; set; }

        [Required]
        [PasswordPropertyText]
        public string? Password { get; set; }
    }
}

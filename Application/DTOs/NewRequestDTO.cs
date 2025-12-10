using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class NewRequestDTO
    {
        [Required]
        public DateTime StardDate { get; set; }
        [Required]
        public DateTime FinishDateDate { get; set; }

        public string? Reason { get; set; }
    }
}

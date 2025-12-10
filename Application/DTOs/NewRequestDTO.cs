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
        public DateTime StardDate { get; set; }
        public DateTime FinishDateDate { get; set; }

        public string? Reason { get; set; }
    }
}

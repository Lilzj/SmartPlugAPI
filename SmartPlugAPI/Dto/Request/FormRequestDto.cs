using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPlugAPI.Dto.Request
{
    public class FormRequestDto
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerFeedback { get; init; }
        public string CollectionName { get; set; }
        public string DatabaseName { get; set; }
    }
}

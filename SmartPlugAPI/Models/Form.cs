using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPlugAPI.Models
{
    public class Form
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CustomerName { get; init; }
        public string CustomerEmail { get; init; }
        public string CustomerFeedback { get; init; }
        public string CollectionName { get; set; } = "sparkPlugFeedback";
        public string DatabaseName { get; set; } = "localhost";
        public string CreationDate { get; set; } = DateTime.Now.ToString();
    }
}

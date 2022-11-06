using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Models
{
    public class ContactInfo:Base
    {
        public string ContactId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}

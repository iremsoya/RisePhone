using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Models
{
    public class ContactInfo:Base
    {
        public int ContactId { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
    }
}

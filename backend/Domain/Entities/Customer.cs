using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string? Name { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public string? GST { get; set; }
    }

}

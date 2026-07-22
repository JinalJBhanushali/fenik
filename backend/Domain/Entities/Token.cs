using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class Token : BaseEntity
    {
        public string? UserId { get; set; }
        public string? RefreshToken { get; set; }
        public DateTimeOffset ExpiryDate { get; set; }
    }
}

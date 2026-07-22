using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PurchaseOrderItem : BaseEntity
    {
        public string? PurchaseOrderId { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
        public string? ProductId { get; set; }
        public Product? Product { get; set; }
        public string? Summary { get; set; }
        public double? UnitPrice { get; set; } = 0;
        public double? Quantity { get; set; } = 1;
        public double? Total { get; set; } = 0;
    }

}

using System;
using System.Collections.Generic;

namespace WingtipToys.Models
{
    public partial class OrderDetailsDto
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string Username { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double? UnitPrice { get; set; }

        public virtual OrdersDto Order { get; set; }
    }
}

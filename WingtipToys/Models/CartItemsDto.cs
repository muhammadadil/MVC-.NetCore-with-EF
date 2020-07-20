using System;
using System.Collections.Generic;

namespace WingtipToys.Models
{
    public partial class CartItemsDto
    {
        public string ItemId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }

        public virtual ProductsDto Product { get; set; }
    }
}

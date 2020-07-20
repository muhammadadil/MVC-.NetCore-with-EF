using System;
using System.Collections.Generic;

namespace WingtipToys.Models
{
    public partial class ProductsDto
    {
        public ProductsDto()
        {
            CartItems = new HashSet<CartItemsDto>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public double? UnitPrice { get; set; }
        public int? CategoryId { get; set; }

        public virtual CategoriesDto Category { get; set; }
        public virtual ICollection<CartItemsDto> CartItems { get; set; }
    }
}

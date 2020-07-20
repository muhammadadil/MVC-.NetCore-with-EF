using System;
using System.Collections.Generic;

namespace WingtipToys.Models
{
    public partial class CategoriesDto
    {
        public CategoriesDto()
        {
            Products = new HashSet<ProductsDto>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductsDto> Products { get; set; }
    }
}

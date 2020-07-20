using DataAccessLayer;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Services
{
   public class ProductsServices : IProductsServices
    {
        readonly WingtiptoysContext _wingtiptoysContext;
        public ProductsServices(WingtiptoysContext wingtiptoysContext)
        {
            _wingtiptoysContext = wingtiptoysContext;
        }

        public IEnumerable<Products> GetAll()
        {
            return _wingtiptoysContext.Products
                .Include(products => products.Category)              
                .ToList();
        }

        public Products Get(int id)
        {
            var products = _wingtiptoysContext.Products
                .SingleOrDefault(prod => prod.ProductId == id);

            return products;
        }
        public void Add(Products entity)
        {
            _wingtiptoysContext.Products.Add(entity);
            _wingtiptoysContext.SaveChanges();
        }

        public void Update(Products entityToUpdate, Products entity)
        {
            //entityToUpdate = _wingtiptoysContext.Categories
            //    .Include(a => a.Products);
            _wingtiptoysContext.SaveChanges();
        }

        public void Delete(Products entity)
        {
            _wingtiptoysContext.Remove(entity);
            _wingtiptoysContext.SaveChanges();
        }
    }
}

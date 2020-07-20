using DataAccessLayer;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Services
{
   public class CategoryServices: ICategoryServices
    {
        readonly WingtiptoysContext _wingtiptoysContext;
        public CategoryServices(WingtiptoysContext wingtiptoysContext)
        {
            _wingtiptoysContext = wingtiptoysContext;
        }

        public IEnumerable<Categories> GetAll()
        {
            return _wingtiptoysContext.Categories
                .Include(category => category.Products)              
                .ToList();
        }

        public Categories Get(long id)
        {
            var category = _wingtiptoysContext.Categories
                .SingleOrDefault(cat => cat.CategoryId == id);

            return category;
        }

        public Categories GetByName(string name)
        {
            var category = _wingtiptoysContext.Categories
                 .Include(cat => cat.Products)
                 .SingleOrDefault(cat => cat.CategoryName.ToLower() == name.ToLower());             

            return category;
        }

        public void Add(Categories entity)
        {
            _wingtiptoysContext.Categories.Add(entity);
            _wingtiptoysContext.SaveChanges();
        }

        public void Update(Categories entityToUpdate, Categories entity)
        {
            //entityToUpdate = _wingtiptoysContext.Categories
            //    .Include(a => a.Products);
            _wingtiptoysContext.SaveChanges();
        }

        public void Delete(Categories entity)
        {
            _wingtiptoysContext.Remove(entity);
            _wingtiptoysContext.SaveChanges();
        }
    }
}

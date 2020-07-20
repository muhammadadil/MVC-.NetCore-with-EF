using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer
{
   public interface ICategoryServices
    {
        IEnumerable<Categories> GetAll();
        Categories Get(long id);
        Categories GetByName(string name);
        void Add(Categories entity);
        void Update(Categories entityToUpdate, Categories entity);
        void Delete(Categories entity);
    }
}

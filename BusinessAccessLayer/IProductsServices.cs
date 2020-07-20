using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer
{
   public interface IProductsServices
    {
        IEnumerable<Products> GetAll();
        Products Get(int id);
        void Add(Products entity);
        void Update(Products entityToUpdate, Products entity);
        void Delete(Products entity);
    }
}

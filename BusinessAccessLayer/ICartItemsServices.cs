using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer
{
   public interface ICartItemsServices
    {
        IEnumerable<CartItems> GetAll();
        CartItems Get(string id);
        void Add(CartItems entity);
        void Update(CartItems entityToUpdate, CartItems entity);
        void Delete(CartItems entity);
    }
}

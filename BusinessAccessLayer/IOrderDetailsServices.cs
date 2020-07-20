using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer
{
   public interface IOrderDetailsServices
    {
        IEnumerable<OrderDetails> GetAll();
        OrderDetails Get(long id);
        void Add(OrderDetails entity);
        void Update(OrderDetails entityToUpdate, OrderDetails entity);
        void Delete(OrderDetails entity);
    }
}

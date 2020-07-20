using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer
{
   public interface IOrderServices
    {
        IEnumerable<Orders> GetAll();
        Orders Get(long id);
        void Add(Orders entity);
        void Update(Orders entityToUpdate, Orders entity);
        void Delete(Orders entity);
    }
}

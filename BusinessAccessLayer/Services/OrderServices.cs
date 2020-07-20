using DataAccessLayer;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Services
{
   public class OrderServices: IOrderServices
    {
        readonly WingtiptoysContext _wingtiptoysContext;
        public OrderServices(WingtiptoysContext wingtiptoysContext)
        {
            _wingtiptoysContext = wingtiptoysContext;
        }

        public IEnumerable<Orders> GetAll()
        {
            return _wingtiptoysContext.Orders
                .Include(order => order.OrderDetails)
                .ToList();
        }

        public Orders Get(long id)
        {
            var order = _wingtiptoysContext.Orders
                .SingleOrDefault(o => o.OrderId == id);

            return order;
        }
        public void Add(Orders entity)
        {
            _wingtiptoysContext.Orders.Add(entity);
            _wingtiptoysContext.SaveChanges();
        }

        public void Update(Orders entityToUpdate, Orders entity)
        {
            //entityToUpdate = _wingtiptoysContext.Categories
            //    .Include(a => a.Products);
            _wingtiptoysContext.SaveChanges();
        }

        public void Delete(Orders entity)
        {
            _wingtiptoysContext.Remove(entity);
            _wingtiptoysContext.SaveChanges();
        }
    }
}

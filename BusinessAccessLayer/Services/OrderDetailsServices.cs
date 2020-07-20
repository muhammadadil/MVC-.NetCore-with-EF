using DataAccessLayer;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Services
{
   public class OrderDetailsServices:IOrderDetailsServices
    {
        readonly WingtiptoysContext _wingtiptoysContext;
        public OrderDetailsServices(WingtiptoysContext wingtiptoysContext)
        {
            _wingtiptoysContext = wingtiptoysContext;
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            return _wingtiptoysContext.OrderDetails
                .Include(order => order.Order)
                .ToList();
        }

        public OrderDetails Get(long id)
        {
            var OrderDetails = _wingtiptoysContext.OrderDetails
                .SingleOrDefault(o => o.OrderId == id);

            return OrderDetails;
        }
        public void Add(OrderDetails entity)
        {
            _wingtiptoysContext.OrderDetails.Add(entity);
            _wingtiptoysContext.SaveChanges();
        }

        public void Update(OrderDetails entityToUpdate, OrderDetails entity)
        {
            //entityToUpdate = _wingtiptoysContext.Categories
            //    .Include(a => a.Products);
            _wingtiptoysContext.SaveChanges();
        }

        public void Delete(OrderDetails entity)
        {
            _wingtiptoysContext.Remove(entity);
            _wingtiptoysContext.SaveChanges();
        }

    }
}

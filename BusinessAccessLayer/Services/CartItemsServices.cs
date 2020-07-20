using DataAccessLayer;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Services
{
   public class CartItemsServices : ICartItemsServices
    {
        readonly WingtiptoysContext _wingtiptoysContext;
        public CartItemsServices(WingtiptoysContext wingtiptoysContext)
        {
            _wingtiptoysContext = wingtiptoysContext;
        }

        public IEnumerable<CartItems> GetAll()
        {
            return _wingtiptoysContext.CartItems
                .Include(cartItems => cartItems.Product)              
                .ToList();
        }

        public CartItems Get(string id)
        {
            var cartItems = _wingtiptoysContext.CartItems
                .SingleOrDefault(cart => cart.CartId == id);

            return cartItems;
        }
        public void Add(CartItems entity)
        {
            _wingtiptoysContext.CartItems.Add(entity);
            _wingtiptoysContext.SaveChanges();
        }

        public void Update(CartItems entityToUpdate, CartItems entity)
        {
            //entityToUpdate = _wingtiptoysContext.Categories
            //    .Include(a => a.Products);
            _wingtiptoysContext.SaveChanges();
        }

        public void Delete(CartItems entity)
        {
            _wingtiptoysContext.Remove(entity);
            _wingtiptoysContext.SaveChanges();
        }
    }
}

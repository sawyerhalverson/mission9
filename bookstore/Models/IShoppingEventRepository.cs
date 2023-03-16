using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models
{
    public interface IShoppingEventRepository
    { 
        IQueryable<ShoppingEvent> ShoppingEvent { get; }

        void SaveShoppingEvent(ShoppingEvent shoppingEvent);
    }
}

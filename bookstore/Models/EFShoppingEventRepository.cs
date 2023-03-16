using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models
{
    public class EFShoppingEventRepository : IShoppingEventRepository
    {
        private BookstoreContext context;
        public EFShoppingEventRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<ShoppingEvent> ShoppingEvent => context.ShoppingEvents.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveShoppingEvent(ShoppingEvent shoppingEvent)
        {
            context.AttachRange(shoppingEvent.Lines.Select(x => x.Book));

            if (shoppingEvent.ShoppingEventId == 0)
            {
                context.ShoppingEvents.Add(shoppingEvent);
            }
            context.SaveChanges();
        }
    }
}

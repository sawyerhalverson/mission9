using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore.Infrastructure;
using bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bookstore.Pages
{
    public class ShopModel : PageModel
    {
        public IBookstoreRepository repo { get; set; }


        //create cart object
        public Cart cart { get; set; }

        public ShopModel (IBookstoreRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }



        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        //create post method with json session
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);


            cart.AddItem(b, 1);


            //add return url segment
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        //add onpost remove

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new {ReturnUrl = returnUrl});
        }
    }
}

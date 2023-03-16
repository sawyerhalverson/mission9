using bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Controllers
{
    public class ShoppingEventController : Controller
    {
        private IShoppingEventRepository repo { get; set; }

        private Cart cart { get; set; }

        public ShoppingEventController(IShoppingEventRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }



        //create checkout event for get and post

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new ShoppingEvent());
        }


        [HttpPost]

        public IActionResult Checkout(ShoppingEvent shoppingEvent)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }

            if (ModelState.IsValid)
            {
                shoppingEvent.Lines = cart.Items.ToArray();
                repo.SaveShoppingEvent(shoppingEvent);
                cart.ClearCart();

                return RedirectToPage("/CheckoutCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}

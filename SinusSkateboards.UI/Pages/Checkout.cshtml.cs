using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SinusSkateboards.UI.Databas;
using SinusSkateboards.UI.Models;

namespace SinusSkateboards.UI.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly SinusDbContext _context;

        public CheckoutModel(SinusDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CartModel Cart { get; set; }

        public OrderModel Order { get; set; } = new();

        [BindProperty]
        public new UserModel User { get; set; }



        public void OnGet()
        {

            string key = "Cart";

            string cartCookie = Request.Cookies[key];

            if (ModelState.IsValid)
            {

                //Om cookien inte är tom
                if (!String.IsNullOrEmpty(cartCookie))
                {
                    Cart = JsonConvert.DeserializeObject<CartModel>(cartCookie);
                }

                if (Cart != null)
                {
                    foreach (var p in Cart.ProductQuantity)
                    {
                        Cart.Price += p.Product.Price * p.Quantity;
                    }
                }
            }


        }

        public async Task<IActionResult> OnPost()
        {
            string key = "Cart";

            string cartCookie = Request.Cookies[key];

            //Om cookien inte är tom
            if (!String.IsNullOrEmpty(cartCookie))
            {
                Cart = JsonConvert.DeserializeObject<CartModel>(cartCookie);
            }

            if (ModelState.IsValid)
            {

                Order.Products = new List<ProductQuantityModel>();
                
                foreach (var pq in Cart.ProductQuantity)
                {
                    pq.Product = await _context.Product.Include(x => x.Category).Include(x => x.Color).Where(x => x.ProductID == pq.ProductID).SingleAsync();
                    pq.ProductQuantityID = 0;
                    await _context.ProductQuantity.AddAsync(pq);
                    Order.Products.Add(pq);

                }

                Order.User = User;
                Order.OrderDate = DateTime.Now;

               await _context.Order.AddAsync(Order);

                await _context.SaveChangesAsync();

                return RedirectToPage("/OrderDetails", new { Id = Order.OrderID });
            }

            return Page();
        }
    }
}

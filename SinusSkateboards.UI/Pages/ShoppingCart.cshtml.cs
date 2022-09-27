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
    public class ShoppingCartModel : PageModel
    {

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

       
    }
}

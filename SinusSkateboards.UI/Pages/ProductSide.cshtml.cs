using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SinusSkateboards.UI.Databas;
using SinusSkateboards.UI.Models;

namespace SinusSkateboards.UI.Pages
{
    public class ProductSideModel : PageModel
    {
        private readonly SinusDbContext _context;

        public ProductSideModel(SinusDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductModel ProductModel { get; set; }

        public CartModel Cart { get; set; } = new();

        
        public ProductQuantityModel ProductQuantity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.Color).FirstOrDefaultAsync(m => m.ProductID == id);

            if (ProductModel == null)
            {
                return NotFound();
            }
            return Page();
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

            //Om varukorgen inte har en lista av productquantity skapa en och lägg till en productquantity
            if (Cart.ProductQuantity == null)
            {
                Cart.ProductQuantity = new List<ProductQuantityModel>();

                ProductQuantity = new ProductQuantityModel { ProductQuantityID = ProductModel.ProductID, ProductID = ProductModel.ProductID, Quantity = 1 };

                ProductQuantity.Product = await _context.Product.Where(x => x.ProductID == ProductModel.ProductID).Include(x => x.Category).Include(x => x.Color).SingleAsync();

                Cart.ProductQuantity.Add(ProductQuantity);
            }



            //Om varukorgen redan har den produkten, lägg till 1 på quantity
           else if (Cart.ProductQuantity.Any(x => x.ProductID == ProductModel.ProductID))
            {

                Cart.ProductQuantity.FirstOrDefault(x => x.ProductID == ProductModel.ProductID).Quantity += 1;
            }


            //Om produkten inte existerar, skapa en ny
            else
            {
                ProductQuantity = new ProductQuantityModel { ProductQuantityID = ProductModel.ProductID, ProductID = ProductModel.ProductID, Quantity = 1 };

                ProductQuantity.Product = await _context.Product.Where(x => x.ProductID == ProductModel.ProductID).Include(x => x.Category).Include(x => x.Color).SingleAsync();

                Cart.ProductQuantity.Add(ProductQuantity);
            }


            //Omvandlar objektet till en sträng
            cartCookie = JsonConvert.SerializeObject(Cart);

            CookieOptions options = new();

            options.Expires = DateTime.Now.AddDays(4);

            Response.Cookies.Append(key, cartCookie, options);

            return RedirectToPage("/ProductSide", new  {  Id = ProductModel.ProductID });


        }

     
    }
}

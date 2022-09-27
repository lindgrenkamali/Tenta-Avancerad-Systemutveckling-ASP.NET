using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.UI.Databas;
using SinusSkateboards.UI.Models;

namespace SinusSkateboards.UI.Pages
{
    public class OrderDetailsModel : PageModel
    {
        private readonly SinusDbContext _context;

        public OrderDetailsModel(SinusDbContext context)
        {
            _context = context;
        }

        

        [BindProperty]
        public OrderModel Order { get; set; }

        public async Task OnGet(int id)
        {
            //Hämtar Ordern beroende på id
            Order = await _context.Order.Include(x => x.Products).ThenInclude(x => x.Product).ThenInclude(x => x.Category).Include(x => x.Products).ThenInclude(x => x.Product).ThenInclude(x => x.Color).Include(x => x.User).Where(x => id == x.OrderID).SingleAsync();

            CookieOptions options = new();

            //Sätter tiden till minus som tar bort cookien, om den finns
            options.Expires = DateTime.Now.AddDays(-1);

            //Cookien tas bort
            Response.Cookies.Append("Cart", "", options);
        }
    }
}

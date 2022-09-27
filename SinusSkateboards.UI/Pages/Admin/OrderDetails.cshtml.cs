using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.UI.Databas;
using SinusSkateboards.UI.Models;

namespace SinusSkateboards.UI.Pages.Admin
{
    public class OrderDetailsModel : PageModel
    {
        public readonly SinusDbContext _context;

        public OrderDetailsModel(SinusDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderModel Order { get; set; }

        public async Task OnGet(int? id)
        {

            Order = await _context.Order.Include(x => x.Products).ThenInclude(x => x.Product).ThenInclude(x => x.Category).Include(x => x.Products).ThenInclude(x => x.Product).ThenInclude(x => x.Color).Include(x => x.User).Where(x => x.OrderID == id).SingleAsync();

        }
    }
}

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
    public class OrdersModel : PageModel
    {
        public readonly SinusDbContext _context;

        public OrdersModel(SinusDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();

        public async Task OnGet()
        {
            Orders = await _context.Order.ToListAsync();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.UI.Models
{
    public class AdminModel : IdentityUser
    {
        public int AdminID { get; set; }
    }
}

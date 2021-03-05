using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Models;

namespace ProjectShop.Pages.Kvinder
{
    public class KjolerModel : PageModel
    {
        private readonly ProjectShop.Data.ProductShopContext _context;

        public KjolerModel(ProjectShop.Data.ProductShopContext context)
        {
            _context = context;
        }

        public IList<Kvinde> Kvinde { get; set; }

        public async Task OnGetAsync()
        {
            Kvinde = await _context.Kvinder
                .Include(k => k.Product)
                .Include(k => k.Tøjtype).ToListAsync();
        }
    }
}

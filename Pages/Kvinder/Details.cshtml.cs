using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models;

namespace ProjectShop.Pages.Kvinder
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectShop.Data.ProductShopContext _context;

        public DetailsModel(ProjectShop.Data.ProductShopContext context)
        {
            _context = context;
        }

        public Kvinde Kvinde { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kvinde = await _context.Kvinder
                .Include(k => k.Product)
                .Include(k => k.Tøjtype).FirstOrDefaultAsync(m => m.KvindeID == id);

            if (Kvinde == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

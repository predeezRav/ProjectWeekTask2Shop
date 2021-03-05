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
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProductShopContext _context;

        public DeleteModel(ProjectShop.Data.ProductShopContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kvinde = await _context.Kvinder.FindAsync(id);

            if (Kvinde != null)
            {
                _context.Kvinder.Remove(Kvinde);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

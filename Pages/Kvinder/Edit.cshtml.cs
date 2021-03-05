using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models;

namespace ProjectShop.Pages.Kvinder
{
    public class EditModel : PageModel
    {
        private readonly ProjectShop.Data.ProductShopContext _context;

        public EditModel(ProjectShop.Data.ProductShopContext context)
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
           ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ID");
           ViewData["TøjtypeID"] = new SelectList(_context.Tøjtyper, "TøjtypeID", "TøjtypeID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Kvinde).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KvindeExists(Kvinde.KvindeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KvindeExists(int id)
        {
            return _context.Kvinder.Any(e => e.KvindeID == id);
        }
    }
}

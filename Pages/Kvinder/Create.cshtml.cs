using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectShop.Data;
using ProjectShop.Models;

namespace ProjectShop.Pages.Kvinder
{
    public class CreateModel : PageModel
    {
        private readonly ProjectShop.Data.ProductShopContext _context;

        public CreateModel(ProjectShop.Data.ProductShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ID");
        ViewData["TøjtypeID"] = new SelectList(_context.Tøjtyper, "TøjtypeID", "TøjtypeID");
            return Page();
        }

        [BindProperty]
        public Kvinde Kvinde { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Kvinder.Add(Kvinde);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using webCRUD2._2.Data;
using webCRUD2._2.Models;

namespace webCRUD2._2.Pages
{
    public class CreateModel : PageModel
    {
        private readonly webCRUD2._2.Data.EmpContext _context;

        public CreateModel(webCRUD2._2.Data.EmpContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public empleado empleado { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.empleado.Add(empleado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webCRUD2._2.Data;
using webCRUD2._2.Models;

namespace webCRUD2._2.Pages
{
    public class EditModel : PageModel
    {
        private readonly webCRUD2._2.Data.EmpContext _context;

        public EditModel(webCRUD2._2.Data.EmpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public empleado empleado { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            empleado = await _context.empleado.FirstOrDefaultAsync(m => m.empid == id);

            if (empleado == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!empleadoExists(empleado.empid))
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

        private bool empleadoExists(int id)
        {
            return _context.empleado.Any(e => e.empid == id);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webCRUD2._2.Data;
using webCRUD2._2.Models;

namespace webCRUD2._2.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly webCRUD2._2.Data.EmpContext _context;

        public DeleteModel(webCRUD2._2.Data.EmpContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            empleado = await _context.empleado.FindAsync(id);

            if (empleado != null)
            {
                _context.empleado.Remove(empleado);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

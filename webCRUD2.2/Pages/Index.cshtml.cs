using System;
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
    public class IndexModel : PageModel
    {
        private readonly webCRUD2._2.Data.EmpContext _context;

        public IndexModel(webCRUD2._2.Data.EmpContext context)
        {
            _context = context;
        }

        public IList<empleado> empleado { get;set; }

        public async Task OnGetAsync()
        {
            empleado = await _context.empleado.ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webCRUD2._2.Models;

namespace webCRUD2._2.Data
{
    public class EmpContext : DbContext
    {
        public EmpContext (DbContextOptions<EmpContext> options)
            : base(options)
        {
        }

        public DbSet<webCRUD2._2.Models.empleado> empleado { get; set; }
    }
}

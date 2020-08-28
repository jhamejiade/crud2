using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webCRUD2._2.Models
{
    public class empleado
    {
        [Key]
        public int empid { get; set; }
        public string empnom { get; set; }
        public string email { get; set; }
        public int salario { get; set; }

    }
}

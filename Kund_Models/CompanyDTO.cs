using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kund_Models
{
    public class CompanyDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Detta fält får inte lämnas blankt")]
        public string? CompanyName { get; set; }
    }
}

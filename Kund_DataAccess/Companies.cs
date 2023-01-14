using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kund_DataAccess
{
    public class Companies
    {
        // Om man vill ha ett unikt id kan man använda Guid istället för int
        //[Key]
        //public Guid CompanyId { get; set; }

        [Key]
        public int Id { get; set; }
        public string? CompanyName { get; set; }
    }
}

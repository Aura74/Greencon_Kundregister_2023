using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kund_DataAccess
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Desciption { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }

        public int CompaniesId { get; set; }
        [ForeignKey("CompaniesId")]
        public Companies? Companies { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kund_Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Desciption { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Välj ett företag")]
        public int CompaniesId { get; set; }
        public CompanyDTO? Companies { get; set; }
    }
}

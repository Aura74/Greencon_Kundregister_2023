using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kund_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        // En konstruktor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // kommer skapa en table i sql databasen
        public DbSet<Companies> Company { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredMvcDemo.Domain.Models;

namespace LayeredMvcDemo.DataAccess
{
    public class SouthwindContext : DbContext
    {
        public SouthwindContext() : base("SouthwindDB")
        {
            Database.SetInitializer<SouthwindContext>(new SouthwindDBInitializer());
        }

        public DbSet<Customer> Customers { get; set; }
    }   
}

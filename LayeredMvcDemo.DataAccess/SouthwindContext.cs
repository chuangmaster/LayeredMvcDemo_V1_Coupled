using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LayeredMvcDemo.Domain.Models;

namespace LayeredMvcDemo.DataAccess
{
    public class SouthwindContext : DbContext
    {
        public SouthwindContext() : base("SouthwindDB")
        {
            Database.SetInitializer<SouthwindContext>(new SouthwindDBInitializer());
        }

        public SouthwindContext(string connStr) : base(connStr)
        {
            Database.SetInitializer<SouthwindContext>(new SouthwindDBInitializer());
        }

        public static SouthwindContext InstanceInCurrentRequest
        {
            get
            {
                return HttpContext.Current.Items["DbContext"] as SouthwindContext;
            }
        }

        public DbSet<Customer> Customers { get; set; }
    }   
}

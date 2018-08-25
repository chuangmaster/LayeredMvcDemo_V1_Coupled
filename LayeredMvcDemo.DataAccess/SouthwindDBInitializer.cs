using LayeredMvcDemo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredMvcDemo.DataAccess
{
    public class SouthwindDBInitializer : CreateDatabaseIfNotExists<SouthwindContext>
    {
        public override void InitializeDatabase(SouthwindContext context)
        {
            base.InitializeDatabase(context);

            context.Customers.Add(new Customer
            {
                Id = 1,
                CompanyName = "MikeSoft",
                Contact = "Michael"
            });
            context.Customers.Add(new Customer
            {
                Id = 2,
                CompanyName = "OralCall",
                Contact = "Vivid"
            });
            context.Customers.Add(new Customer
            {
                Id = 3,
                CompanyName = "SimonTech",
                Contact = "Simon"
            });
            context.Customers.Add(new Customer
            {
                Id = 4,
                CompanyName = "IoSee",
                Contact = "Mark"
            });

            context.SaveChanges();
        }
    }
}

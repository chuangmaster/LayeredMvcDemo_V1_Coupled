using LayeredMvcDemo.Application.Interfaces;
using LayeredMvcDemo.DataAccess;
using LayeredMvcDemo.DataAccess.Interfaces;
using LayeredMvcDemo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredMvcDemo.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly SouthwindContext db;

        public CustomerService()
        {
            //預設
            db = SouthwindContext.InstanceInCurrentRequest;
        }
        public CustomerService(SouthwindContext context)
        {
            //如果外部有提供
            db = context;
        }
        public Customer GetCustomerById(int id)
        {
            return db.Customers.Find(id);
        }
        public List<Customer> GetCustomerList(Func<Customer, bool> filter)
        {
            return db.Customers.Where(filter).ToList();
        }
    }
}

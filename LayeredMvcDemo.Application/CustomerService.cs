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
        private readonly ICustomerRepository repository = new CustomerRepository();
        public CustomerService(ICustomerRepository repository)
        {
            this.repository = repository;
        }
        public Customer GetCustomerById(int id)
        {
            return repository.GetCustomerById(id);
        }
        public List<Customer> GetCustomerList(Func<Customer, bool> filter)
        {
            return repository.GetCustomerList(filter).ToList();
        }
    }
}

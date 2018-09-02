using LayeredMvcDemo.Application.Interfaces;
using LayeredMvcDemo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LayeredMvcDemo_V1_Coupled.Controllers.API
{
    public class CustomerController : ApiController
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("~/api/customer/{id}")]
        public Customer Get(int id)
        {
            return _customerService.GetCustomerById(id);
        }        [HttpGet]
        [Route("~/api/customer")]
        public List<Customer> GetCustomerCollection()
        {
            return _customerService.GetCustomerList(x => x.Id != 0);
        }
    }
}

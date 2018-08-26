using LayeredMvcDemo.Application;
using LayeredMvcDemo.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayeredMvcDemo_V1_Coupled.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerService customerService;
        public HomeController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public ActionResult Index()
        {
            var customers = customerService.GetCustomerList(cust => cust.Id < 4);
            return View(customers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
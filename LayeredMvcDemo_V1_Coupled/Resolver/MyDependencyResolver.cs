﻿using LayeredMvcDemo.Application;
using LayeredMvcDemo_V1_Coupled.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace LayeredMvcDemo_V1_Coupled.Resolver
{
    public class MyDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _container;
        public object GetService(Type serviceType)
        {
            // 觀察 MVC 框架有哪些服務會透過 dependency resolver 來解析。
            System.Diagnostics.Debug.WriteLine(serviceType.FullName);
            // 解析特定 controller。
            if (serviceType == typeof(HomeController))
            {
                var customerSvc = new CustomerService();
                var controller = new HomeController(customerSvc);
                return controller;
            }
            // 不需要在此解析的型別，必須傳回 null。（不可拋異常！）
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            // 沒有特別要解析的型別，故傳回空集合。（不可拋異常！）
            return new List<object>();
        }
    }
}
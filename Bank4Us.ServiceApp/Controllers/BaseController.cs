
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bank4Us.BusinessLayer.Core;
using Microsoft.Extensions.Logging;
using Bank4Us.Common.Facade;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Bank4Us.BusinessLayer.Managers.OrderManagement;
using Bank4Us.BusinessLayer.Managers.ProductManagement;


namespace  Bank4Us.ServiceApp.Controllers
{
    /// <summary>
    ///   COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Matthew Valentino
    ///   Description: Assignment 9 focusing on creating a service application
    /// 
    /// </summary>
    /// 

    //Essentially the same as from textbook, just added new methods
    //For Order and Product
    public class BaseController : Controller
    {
        private IActionManager _manager;
        private ILogger _logger;
        private IOrderManager manager;
        private ILogger<OrderController> logger;
        private IProductManager manager1;
        private ILogger<ProductController> logger1;

        public BaseController(IActionManager manager, ILogger logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public BaseController(IOrderManager manager, ILogger<OrderController> logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        public BaseController(IProductManager manager1, ILogger<ProductController> logger1)
        {
            this.manager1 = manager1;
            this.logger1 = logger1;
        }

        public IActionManager ActionManager { get { return _manager; } }
        public ILogger Logger { get { return _logger; } }
       
        protected HttpResponseException LogException(Exception ex)
        {
            string errorMessage = LoggerHelper.GetExceptionDetails(ex);
            _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, errorMessage);
            HttpResponseMessage message = new HttpResponseMessage();
            message.Content = new StringContent(errorMessage);
            message.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
            throw new HttpResponseException(message);
        }

    }
}

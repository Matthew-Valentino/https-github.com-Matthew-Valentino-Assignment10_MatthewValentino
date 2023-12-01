using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bank4Us.ServiceApp.Filters;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.BusinessLayer.Managers.OrderManagement;
using Bank4Us.Common.Facade;

namespace Bank4Us.ServiceApp.Controllers
{  
    /// <summary>
     ///   Course Name: MSCS 6360 Enterprise Architecture
     ///   Year: Fall 2023
     ///   Name: Matthew Valentino
     ///    Description: Assignment 9 focusing on creating a service application         
     /// </summary>
     /// 
    [LoggingActionFilter]
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly OrderManager _manager;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderManager manager, ILogger<OrderController> logger) : base(manager, logger)
        {
            _manager = (OrderManager)manager;
            _logger = logger;
        }

        [TransactionActionFilter()]
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                var orders = _manager.GetAllOrders();
                return new OkObjectResult(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [TransactionActionFilter()]
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                var order = _manager.GetOrder(id);
                if (order != null)
                {
                    return new OkObjectResult(order);
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [TransactionActionFilter()]
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            try
            {
                _manager.Create(order);
                return new OkObjectResult(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [TransactionActionFilter()]
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order order)
        {
            try
            {
                _manager.Update(order);
                return new OkObjectResult(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [TransactionActionFilter()]
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(Order order)
        {
            try
            {
                _manager.Delete(order);
                return new OkResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}

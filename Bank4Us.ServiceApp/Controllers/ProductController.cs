using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bank4Us.ServiceApp.Filters;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.BusinessLayer.Managers.ProductManagement;
using System;
using System.Collections.Generic;
using Bank4Us.Common.Facade;

namespace Bank4Us.ServiceApp.Controllers
{
    /// <summary>
    ///   Course Name: MSCS 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Matthew Valentino
    ///    Description: Assignment 9 focusing on creating a service application         
    /// </summary>
    /// s
    [LoggingActionFilter]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly ProductManager _manager;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductManager manager, ILogger<ProductController> logger) : base(manager, logger)
        {
            _manager = (ProductManager)manager;
            _logger = logger;
        }

        [TransactionActionFilter()]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _manager.GetAllProducts();
                return new OkObjectResult(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [TransactionActionFilter()]
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _manager.GetProduct(id);
                if (product != null)
                {
                    return new OkObjectResult(product);
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
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                _manager.Create(product);
                return new OkObjectResult(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [TransactionActionFilter()]
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            try
            {
                _manager.Update(product);
                return new OkObjectResult(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [TransactionActionFilter()]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Product product)
        {
            try
            {
                _manager.Delete(product);
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

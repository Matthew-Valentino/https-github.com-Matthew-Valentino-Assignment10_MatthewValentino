using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.DataAccess.Core;
using Bank4Us.BusinessLayer.Core;
using Microsoft.Extensions.Logging;
using Bank4Us.Common.Core;
using Bank4Us.Common.Facade;
using Microsoft.EntityFrameworkCore;
using NRules;
using NRules.Fluent;
using NRules.RuleModel;
using Bank4Us.BusinessLayer.Managers.CustomerManagement;

namespace Bank4Us.BusinessLayer.Managers.OrderManagement
{
    /// <summary>
    ///   COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Matthew Valentino
    ///   Description: Assignment 9 focusing on creating a business layer              
    /// </summary>
    /// 

    public class OrderManager : BusinessManager, IOrderManager
    {
        private IRepository _repository;
        private ILogger<OrderManager> _logger;
        private IUnitOfWork _unitOfWork;
        private ICustomerManager _customerManager;
        private ISession _businessRulesEngine;
        public IUnitOfWork UnitOfWork => _unitOfWork;
        List<String> _businessRuleNotifications;

        public OrderManager(IRepository repository, ILogger<OrderManager> logger, IUnitOfWork unitOfWork, ICustomerManager customerManager, ISession businessRulesEngine) : base()
        {
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _customerManager = customerManager;
            _businessRulesEngine = businessRulesEngine;
        }

        public virtual Order GetOrder(int orderId)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, "Getting order with ID " + orderId);
                return _repository.All<Order>().FirstOrDefault(o => o.Id == orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<String> BusinessRuleNotifications
        {
            get
            {
                return _businessRuleNotifications;
            }
        }

        public void Create(Order order)
        {
            try
            {
                _logger.LogInformation("Creating order");
                _repository.Create<Order>(order);
                SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating order: {ex.Message}");
                throw;
            }
        }

        public void Update(Order order)
        {
            try
            {
                _logger.LogInformation("Updating order");
                _repository.Update<Order>(order);
                SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating order: {ex.Message}");
                throw;
            }
        }

        public void Delete(Order order)
        {
            try
            {
                _logger.LogInformation("Deleting order");
                _repository.Delete<Order>(order);
                SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting order: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            try
            {
                _logger.LogInformation("Retrieving all orders");
                return _repository.All<Order>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving orders: {ex.Message}");
                throw;
            }
        }
            public void SaveChanges()
            {
                _unitOfWork.SaveChanges();
            }

        }
    } 

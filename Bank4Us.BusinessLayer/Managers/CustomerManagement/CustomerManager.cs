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

namespace Bank4Us.BusinessLayer.Managers.CustomerManagement
{
    /// <summary>
    ///   COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Matthew Valentino
    ///   Description: Assignment 9 focusing on creating a business layer              
    /// </summary>
    /// 

    public class CustomerManager : BusinessManager, ICustomerManager
    {
        //Most of the "*Manager" files are very similar with terms switched out
        IRepository _repository;
        NRules.ISession _businessRulesEngine;
        ILogger<CustomerManager> _logger;
        IUnitOfWork _unitOfWork;
        List<String> _businessRuleNotifications;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public CustomerManager(IRepository repository, ILogger<CustomerManager> logger, IUnitOfWork unitOfWork, NRules.ISession businessRulesEngine) : base()
        {
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _businessRulesEngine = businessRulesEngine;
            
        }

        public virtual Customer GetCustomer(int customerId)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, "The customer Id is " + customerId.ToString());
                return _repository.All<Customer>().Where(c => c.Id == customerId).FirstOrDefault();
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


        public void Create(BaseEntity entity)
        {
            Customer customer = (Customer)entity;
            _logger.LogInformation("Creating record for {0}", this.GetType());

            _businessRulesEngine.Insert(customer);
            if (customer.Accounts != null) _businessRulesEngine.InsertAll(customer.Accounts);

            _businessRulesEngine.Fire();
            _businessRuleNotifications = customer.BusinessRuleNotifications;

            if (customer.Accounts != null) _businessRuleNotifications.AddRange(customer.Accounts.SelectMany(a => a.BusinessRuleNotifications).ToList());
            _repository.Create<Customer>(customer);
            if (customer.State != (int)BaseEntity.EntityState.Ignore) SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        
        }
        

        public void Update(BaseEntity entity)
        {
            Customer customer = (Customer)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());

            _businessRulesEngine.Insert(customer);
            if (customer.Accounts != null) _businessRulesEngine.InsertAll(customer.Accounts);

            _businessRulesEngine.Fire();
            _businessRuleNotifications = customer.BusinessRuleNotifications;

            if (customer.Accounts != null) _businessRuleNotifications.AddRange(customer.Accounts.SelectMany(a => a.BusinessRuleNotifications).ToList());
            _repository.Update<Customer>(customer);
            if (customer.State != (int)BaseEntity.EntityState.Ignore) SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Delete(BaseEntity entity)
        {
            Customer customer = (Customer)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());
            _repository.Delete<Customer>(customer);
            SaveChanges();
            _logger.LogInformation("Record deleted for {0}", this.GetType());
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<Customer>().ToList<BaseEntity>();
        }


        public IEnumerable<Customer> GetAllCustomers()
        {
            return _repository.All<Customer>().Include(c=>c.Accounts).ToList(); 
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}

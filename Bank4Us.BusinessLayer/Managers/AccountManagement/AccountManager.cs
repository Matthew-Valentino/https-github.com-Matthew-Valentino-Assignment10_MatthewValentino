using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.BusinessLayer.Core;
using Bank4Us.DataAccess.Core;
using Microsoft.Extensions.Logging;
using Bank4Us.Common.Facade;
using Bank4Us.Common.Core;
using Bank4Us.BusinessLayer.Managers.CustomerManagement;

namespace Bank4Us.BusinessLayer.Managers.AccountManagement
{

    /// <summary>
    ///   COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Matthew Valentino
    ///   Description: Assignment 9 focusing on creating a business layer              
    /// </summary>
    /// 
    public class AccountManager : BusinessManager , IAccountManager
    {
      
        //Most of this file is sam as book, just adding
        // servicerequestmanager along with businessruleengine and notifications
        private IRepository _repository;
        private ILogger<AccountManager> _logger;
        private IUnitOfWork _unitOfWork;
        private ICustomerManager _serviceRequestManager;
        private NRules.ISession _businessRulesEngine;
        private List<String> _businessRuleNotifications;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public AccountManager(IRepository repository, ILogger<AccountManager> logger,  IUnitOfWork unitOfWork, ICustomerManager serviceRequestManager, NRules.ISession businessRulesEngine) : base()
        {
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _serviceRequestManager = serviceRequestManager;
            _businessRulesEngine = businessRulesEngine;
        }

        public virtual Account GetAccount(int accountId)
        {
            try 
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, "The account Id is " + accountId.ToString());
                return _repository.All<Account>().Where(a => a.Id == accountId).FirstOrDefault();
            }catch(Exception ex)
            {
                throw ex;
            }
               
        }

        //important to add notification to all manager files to ensure
        //rules are being met
        //Also, must return the nortifications and not just add them as a list to the manager files
        public List<String> BusinessRuleNotifications
        {
            get
            {
                return _businessRuleNotifications;
            }
        }
        //The following methods are essentially the book methods,
        //just adding the rulesengine logic
        public void Create(BaseEntity entity)
        {
            Account account = (Account)entity;
            _logger.LogInformation("Creating record for {0}", this.GetType());
            _businessRulesEngine.Insert(account);
            _businessRulesEngine.Fire();
            _businessRuleNotifications = account.BusinessRuleNotifications;
            _repository.Create<Account>(account);
            SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Update(BaseEntity entity)
        {
            Account account = (Account)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());
            _businessRulesEngine.Insert(account);
            _businessRulesEngine.Fire();
            _businessRuleNotifications = account.BusinessRuleNotifications;
            _repository.Update<Account>(account);
            SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Delete(BaseEntity entity)
        {
            Account account = (Account)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());
            _repository.Delete<Account>(account);
            SaveChanges();
            _logger.LogInformation("Record deleted for {0}", this.GetType());
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _repository.All<Account>().ToList();
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<Account>().ToList<BaseEntity>();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}

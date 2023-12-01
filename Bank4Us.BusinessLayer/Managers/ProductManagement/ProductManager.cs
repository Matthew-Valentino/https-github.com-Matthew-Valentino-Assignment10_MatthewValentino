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
using NRules;

namespace Bank4Us.BusinessLayer.Managers.ProductManagement
{
    public class ProductManager : BusinessManager, IProductManager
    {
        private IRepository _repository;
        private ILogger<ProductManager> _logger;
        private IUnitOfWork _unitOfWork;
        private NRules.ISession _businessRulesEngine;
        private List<String> _businessRuleNotifications;

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public ProductManager(IRepository repository, ILogger<ProductManager> logger, IUnitOfWork unitOfWork, ISession businessRulesEngine) : base()
        {
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _businessRulesEngine = businessRulesEngine;
        }

        public virtual Product GetProduct(int productId)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, "Getting product with ID " + productId);
                return _repository.All<Product>().FirstOrDefault(p => p.Id == productId);
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


        public void Create(Product product)
        {
            _logger.LogInformation("Creating record for {0}", this.GetType());

            _businessRulesEngine.Insert(product);
            _businessRulesEngine.Fire();
            _businessRuleNotifications = product.BusinessRuleNotifications;
            _repository.Create<Product>(product);
            SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Update(Product product)
        {
            _logger.LogInformation("Updating record for {0}", this.GetType());

            _businessRulesEngine.Insert(product);
            _businessRulesEngine.Fire();
            _businessRuleNotifications = product.BusinessRuleNotifications;
            _repository.Update<Product>(product);
            if (product.State != (int)BaseEntity.EntityState.Ignore) SaveChanges();
            _logger.LogInformation("Record updated for {0}", this.GetType());
        }

        public void Delete(Product product)
        {
            _logger.LogInformation("Deleting record for {0}", this.GetType());
            _repository.Delete<Product>(product);
            SaveChanges();
            _logger.LogInformation("Record deleted for {0}", this.GetType());
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.All<Product>().ToList();
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<Product>().ToList<BaseEntity>();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}

using Bank4Us.BusinessLayer.Managers.CustomerManagement;
using Bank4Us.BusinessLayer.Managers.AccountManagement;
using Bank4Us.DataAccess.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank4Us.BusinessLayer.Managers.ProductManagement;
using Bank4Us.BusinessLayer.Managers.OrderManagement;
namespace Bank4Us.BusinessLayer.Core
{
    /// <summary>
    ///   COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Matthew Valentino
    ///   Description: Assignment 9 focusing on creating a business layer              
    /// </summary>
    /// 
    public class BusinessManagerFactory  
    {
        ICustomerManager _customerManager;
        IAccountManager _accountManager;
        IOrderManager _orderManager;
        IProductManager _productManager;
        public BusinessManagerFactory(ICustomerManager customerManager=null, IAccountManager accountManager=null, IOrderManager orderManager=null, IProductManager productManager= null)
        {
            _customerManager = customerManager;
            _accountManager = accountManager;
            _orderManager = orderManager;
            _productManager = productManager;
        }

        public ICustomerManager GetCustomerManager()
        {
            return _customerManager;
        }

        public IAccountManager GetAccountManager()
        {
            return _accountManager;
        }
        public IOrderManager GetOrderManager()
        {
            return _orderManager;
        }
        public IProductManager GetProductManager()
        {
            return _productManager;
        }      

    }

   

}

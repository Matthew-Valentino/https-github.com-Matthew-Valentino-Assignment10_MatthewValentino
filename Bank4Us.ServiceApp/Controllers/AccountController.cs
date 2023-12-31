﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.BusinessLayer.Managers.AccountManagement;
using System.Net.Http;
using System.Net;
using Bank4Us.ServiceApp.Filters;
using Bank4Us.BusinessLayer.Core;
using Microsoft.Extensions.Logging;
using Bank4Us.Common.Facade;
using Microsoft.AspNetCore.Authorization;


namespace Bank4Us.ServiceApp.Controllers
{

    /// <summary>
    ///   COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Matthew Valentino
    ///   Description: Assignment 9 focusing on creating a service application           
    /// </summary>
    /// 

    // [Authorize]
    [LoggingActionFilter]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        //Note: most of the code from the Controllers refers to the textbook with assistance from Dr. Leannah's Github
        private AccountManager _manager;
        private ILogger _logger;

        public AccountController(IAccountManager manager, ILogger<AccountController> logger) : base(manager, logger)
        {
            _manager = (AccountManager)manager;
            _logger = logger;
        }
        [TransactionActionFilter()]
        [HttpGet]
        [Route("baseentities")]
        public IActionResult GetAllBaseEntities()
        {
            try
            {
                var items = _manager.GetAll();
                return new OkObjectResult(items);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpGet]
        [Route("accounts")]
        public IActionResult GetAllAccounts()
        {
            try
            {
                var items = _manager.GetAllAccounts();
                return new OkObjectResult(items);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpPost]
        public IActionResult Post(Account account)
        {
            try
            {
                _manager.Create(account);
                return new OkObjectResult(_manager.BusinessRuleNotifications);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
        [TransactionActionFilter()]
        [HttpPut]
        public IActionResult Put(Account account)
        {
            try
            {
                _manager.Update(account);
                return new OkObjectResult(_manager.BusinessRuleNotifications);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpDelete]
        public IActionResult Delete(Account account)
        {
            try
            {
                _manager.Delete(account);
                return new OkResult();

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpGet]
        [Route("accounts/{accountId}")]
        public IActionResult GetAccountByAccountId(int accountId)
        {
            try
            {
                var account = _manager.GetAccount(accountId);
                if (account != null)
                {
                    return new OkObjectResult(account);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
    }

}

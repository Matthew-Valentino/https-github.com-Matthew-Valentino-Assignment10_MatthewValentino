﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank4Us.DataAccess.Core;

namespace Bank4Us.DataAccess.Core
{

    /// <summary>
    ///   Course Name: MSCS 6360 Enterprise Architecture
    ///   Year: Fall 2023
    /// Name: Matthew Valentino  
    ///   Description: Homework 8 focusing on entity framework core
    /// </summary>
    public class DbFactory : IDbFactory, IDisposable
    {

        private DataContext _dataContext;
        public DbFactory(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public DataContext GetDataContext
        {
            get
            {
                return _dataContext;
            }
        }

        #region Disposing 

        private bool isDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                if (_dataContext != null)
                {
                    _dataContext.Dispose();
                }
            }
            isDisposed = true;
        }

        #endregion
    }
}

using System;
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
    public interface IDbFactory
    {

        DataContext GetDataContext { get; }
    }
}

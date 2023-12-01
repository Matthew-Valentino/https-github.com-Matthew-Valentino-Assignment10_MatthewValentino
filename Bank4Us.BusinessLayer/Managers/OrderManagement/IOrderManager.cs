using Bank4Us.BusinessLayer.Core;
using Bank4Us.Common.CanonicalSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank4Us.BusinessLayer.Managers.OrderManagement
{
    /// <summary>
    ///   COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Matthew Valentino
    ///   Description: Assignment 9 focusing on creating a business layer              
    /// </summary>
    /// 
    public interface IOrderManager
    {
        Order GetOrder(int Id);
        void Create(Order order);
        void Update(Order order);
        void Delete(Order order);
        IEnumerable<Order> GetAllOrders();
    }
}

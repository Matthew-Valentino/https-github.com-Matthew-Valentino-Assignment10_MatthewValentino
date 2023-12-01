using System;
using System.Collections.Generic;
using System.Text;
using Bank4Us.Common.CanonicalSchema;
using NRules.Fluent.Dsl;
using Bank4Us.Common.Core;

/// <summary>
///   COSC 6360 Enterprise Architecture
///   Year: Fall 2023
///   Name: Matthew Valentino
///   Description: Assignment 9 focusing on creating a business layer              
/// </summary>
/// 
namespace Bank4Us.BusinessLayer.Rules
{
    public class DepositTimeConstraintRule : Rule
    {
        public override void Define()
        {
            Order order = null;

            When()
                .Match<Order>(() => order, o => o.IsDeposit() && !o.IsWithinProcessingTime());
            //Rule: Deposits must be made by 5 pm 
            Then()
                   .Do(ctx => ctx.Update(order))
                   .Do(ctx => order.BusinessRuleNotifications.Add("Deposits must be made before 5pm for same-day processing."));
        }
    }
}

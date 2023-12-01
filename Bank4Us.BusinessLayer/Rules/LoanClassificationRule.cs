using System;
using System.Collections.Generic;
using System.Text;
using Bank4Us.Common.CanonicalSchema;
using NRules.Fluent.Dsl;
using Bank4Us.Common.Core;
using System.Linq;

/// <summary>
///   COSC 6360 Enterprise Architecture
///   Year: Fall 2023
///   Name: Matthew Valentino
///   Description: Assignment 9 focusing on creating a business layer              
/// </summary>

namespace Bank4Us.BusinessLayer.Rules
{
    public class LoanClassificationRule : Rule
    {
        public override void Define()
        {
            Customer customer = null;

            When()
                .Match<Customer>(() => customer, c => c.Accounts != null && c.Accounts.Any(a => !a.IsLoanApproved));

            //Rule: All loans must be approved by bank before given out
            Then()
                .Do(ctx => ctx.Update(customer))
                .Do(ctx => customer.BusinessRuleNotifications.Add("All loans must be approved by the bank."));
        }
    }
}
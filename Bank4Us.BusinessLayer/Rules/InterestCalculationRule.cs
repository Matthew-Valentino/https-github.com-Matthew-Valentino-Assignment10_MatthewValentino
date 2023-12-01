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

namespace Bank4Us.BusinessLayer.Rules
{
    public class InterestCalculationRule : Rule
    {
        public override void Define()
        {
            Account account = null;

            When()
                .Match<Account>(() => account, a => a.ShouldCalculateInterest());

            //Rule: Interest is calculated monthly to ensure that it is accurate
            Then()
                .Do(ctx => account.CalculateInterest())
                .Do(ctx => ctx.Update(account))
                .Do(ctx => account.BusinessRuleNotifications.Add("Interest has been calculated for the account."));
        }
    }
}

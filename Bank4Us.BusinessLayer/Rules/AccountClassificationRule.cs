using System;
using System.Collections.Generic;
using System.Text;
using Bank4Us.Common.CanonicalSchema;
using NRules.Fluent.Dsl;

/// <summary>
///   COSC 6360 Enterprise Architecture
///   Year: Fall 2023
///   Name: Matthew Valentino
///   Description: Assignment 9 focusing on creating a business layer              
/// </summary>
namespace Bank4Us.BusinessLayer.Rules
{
    public class AccountClassificationRule : Rule
    {
        public override void Define()
        {
            Account account = null;

            When()
                .Match<Account>(() => account, a => !a.IsValidAccountType());
            //Rule: account must be a certain type
            Then()
                .Do(ctx => ctx.Update(account))
                .Do(ctx => account.BusinessRuleNotifications.Add("Account must be defined as checking, savings, money market, or certificate of deposit."));
        }
    }
}
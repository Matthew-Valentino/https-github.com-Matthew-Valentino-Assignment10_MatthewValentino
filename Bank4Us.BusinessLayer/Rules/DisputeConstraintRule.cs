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
    public class DisputeConstraintRule : Rule
    {
        public override void Define()
        {
            Account account = null;
            When()
                .Match<Account>(() => account, a => a.HasActiveDispute());
            //Rule: Funds will be held by bank while they are under dispute

            Then()
                .Do(ctx => account.HoldFunds(account.GetDisputeAmount())) 
                .Do(ctx => account.BusinessRuleNotifications.Add("Funds under dispute must be held by bank until issue is resolved."));
        }
    }
}
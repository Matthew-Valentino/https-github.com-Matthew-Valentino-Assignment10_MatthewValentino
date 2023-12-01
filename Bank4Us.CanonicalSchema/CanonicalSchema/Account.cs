using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Bank4Us.Common.Core;
using Newtonsoft.Json;

namespace Bank4Us.Common.CanonicalSchema
{
    /// <summary>
    ///   COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Matthew Valentino
    ///   Description: Assignment 7 focusing on creating Entity Framework Core
    /// </summary>
    /// 
    public class Account : BaseEntity
    {
        public enum AccountTypeEnum
        {
            Checking,
            Savings,
            MoneyMarket,
            CertificateOfDeposit,
            Loan
        }
        public AccountTypeEnum AccountType { get; set; }

        [JsonIgnore]
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public int Status { get; set; }
        public DateTime OpenDate { get; set; }
        public Decimal Balance { get; set; }
        public DateTime LastInterestDate { get; set; }
        public bool IsLoanApproved { get; set; }

        public bool IsActiveDispute { get; set; }

        public bool AreFundsHeld { get; private set; }
        public decimal HeldFundsAmount { get; private set; }
        public decimal DisputedAmount { get; set; }
        public Customer Customer { get; set; }


        // Method to check if the account type is valid
        public bool IsValidAccountType()
        {
            return Enum.IsDefined(typeof(AccountTypeEnum), this.AccountType);
        }
        public decimal GetDisputeAmount()
        {
            // Return the disputed amount
            return DisputedAmount;
        }

        public void HoldFunds(decimal disputeAmount)
        {
            // Ensure the dispute amount is not more than the account balance
            if (disputeAmount > this.Balance)
            {
                throw new InvalidOperationException("Dispute amount cannot exceed account balance.");
            }

            // Mark the account as having held funds
            AreFundsHeld = true;

            // Set the held funds amount
            HeldFundsAmount = disputeAmount;

            // Optionally, you might want to reduce the available balance by the disputed amount
            // Balance -= disputeAmount;
        }
        public void ReleaseHeldFunds()
        {
            if (AreFundsHeld)
            {
                // Reset the flags and held amount
                AreFundsHeld = false;
                HeldFundsAmount = 0;

                // Optionally, restore the held amount to the available balance
                // Balance += HeldFundsAmount;
            }
            else
            {
                throw new InvalidOperationException("No funds are currently held.");
            }
        }
        public void CalculateInterest()
        {
            if (ShouldCalculateInterest())
            {
                // Example: 1% interest rate per month
                this.Balance += (this.Balance * 0.01m);
                this.LastInterestDate = DateTime.Now;
            }
        }

        // Method to determine if interest should be calculated
        public bool ShouldCalculateInterest()
        {
            return DateTime.Now > this.LastInterestDate.AddMonths(1);
        }

        // Method to check if there's an active dispute
        public bool HasActiveDispute()
        {
            return this.IsActiveDispute;
        }

        // Method to check if the account is classified correctly (for loan accounts)
        public bool IsClassifiedCorrectly()
        {
            if (this.AccountType == AccountTypeEnum.Loan) // Assuming 'Loan' is a type
            {
                return this.IsLoanApproved;
            }
            return true; // Other account types are always classified correctly
        }

    }
}

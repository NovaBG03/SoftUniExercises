namespace BillsPaymentSystem.App.Core.Commands
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    using Data;

    public class DepositCommand : Command
    {
        public DepositCommand(BillsPaymentSystemContext context) 
            : base(context)
        {
        }

        public override string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);
            decimal amount = decimal.Parse(args[1]);
            string result = string.Empty;

            if (this.Context.Users.Find(userId) == null)
            {
                throw new InvalidOperationException($"User with userId {userId} does not exist.");
            }

            var paymentMethods = this.Context.PaymentMethods
                .Include(p => p.BankAccount)
                .Include(p => p.CreditCard)
                .Where(p => p.UserId == userId)
                .ToList();

            if (!paymentMethods.Any())
            {
                throw new InvalidOperationException($"User with userId {userId} does not have any payment methoods.");
            }

            var bankAccounts = paymentMethods
                .Where(p => p.BankAccountId != null)
                .Select(p => p.BankAccount)
                .OrderBy(p => p.BankAccountId)
                .ToList();

            var creditCards = paymentMethods
                .Where(p => p.CreditCardId != null)
                .Select(p => p.CreditCard)
                .OrderBy(p => p.CreditCardId)
                .ToList();

            if (bankAccounts.Any())
            {
                var currentBankAccount = bankAccounts.First();
                currentBankAccount.Balance += amount;

                result = $"{amount} added to userId {userId}'s bank account in {currentBankAccount.BankName}";
            }
            else if (creditCards.Any())
            {
                var currentCreditCard = creditCards.FirstOrDefault(c => c.MoneyOwed >= amount);

                if (currentCreditCard == null)
                {
                    throw new InvalidOperationException($"User with userId {userId} does not have bank account or free creditcard.");
                }

                currentCreditCard.MoneyOwed -= amount;

                result = $"{amount} removed from userId {userId}'s creditcard owed money";
            }

            this.Context.SaveChanges();
            return result;
        }
    }
}

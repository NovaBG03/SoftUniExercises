namespace BillsPaymentSystem.App.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    using Data;

    public class WithdrawCommand : Command
    {
        public WithdrawCommand(BillsPaymentSystemContext context)
            : base(context)
        {
        }

        public override string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);
            decimal amount = decimal.Parse(args[1]);
            var result = new StringBuilder();

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

            decimal allMoney = bankAccounts.Sum(b => b.Balance) + creditCards.Sum(c => c.LimitLeft);
            if (allMoney < amount)
            {
                throw new InvalidOperationException($"User with userId {userId} does not have enough money.");
            }

            foreach (var bankAccount in bankAccounts)
            {
                if (bankAccount.Balance < amount)
                {
                    result.AppendLine($"{bankAccount.Balance} removed from userId {userId}'s bank account in {bankAccount.BankName}");

                    amount -= bankAccount.Balance;
                    bankAccount.Balance = 0;
                }
                else
                {
                    result.AppendLine($"{amount} removed from userId {userId}'s bank account in {bankAccount.BankName}");

                    bankAccount.Balance -= amount;
                    amount = 0;
                    break;
                }
            }

            if (amount == 0)
            {
                this.Context.SaveChanges();
                return result.ToString().TrimEnd();
            }

            foreach (var creditCard in creditCards)
            {
                if (creditCard.LimitLeft < amount)
                {
                    result.AppendLine($"{creditCard.LimitLeft} added to userId {userId}'s creditcard owed money");

                    amount -= creditCard.LimitLeft;
                    creditCard.MoneyOwed = creditCard.Limit;
                }
                else
                {
                    result.AppendLine($"{amount} added to userId {userId}'s creditcard owed money");

                    creditCard.MoneyOwed += amount;
                    amount = 0;
                    break;
                }
            }

            this.Context.SaveChanges();
            return result.ToString().TrimEnd();
        }
    }
}

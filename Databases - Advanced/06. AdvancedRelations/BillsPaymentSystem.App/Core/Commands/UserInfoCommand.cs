namespace BillsPaymentSystem.App.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;

    using Data;

    public class UserInfoCommand : Command
    {
        public UserInfoCommand(BillsPaymentSystemContext context) 
            : base(context)
        {
        }

        public override string Execute(string[] args)
        {
            var userId = int.Parse(args.First());

            var user = base.Context.Users
                .Where(u => u.UserId == userId)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    BankAccounts = u.PaymentMethods
                        .Where(p => p.BankAccountId != null)
                        .Select(p => new
                        {
                            p.BankAccount.BankAccountId,
                            p.BankAccount.Balance,
                            p.BankAccount.BankName,
                            p.BankAccount.SwiftCode
                        }),
                    CreditCards = u.PaymentMethods
                        .Where(p => p.CreditCard != null)
                        .Select(p => new
                        {
                            p.CreditCard.CreditCardId,
                            p.CreditCard.Limit,
                            p.CreditCard.MoneyOwed,
                            p.CreditCard.LimitLeft,
                            p.CreditCard.ExpirationDate
                        })
                })
                .FirstOrDefault();

            if (user == null)
            {
                throw new InvalidOperationException($"User with id {userId} not found!");
            }

            var result = new StringBuilder();

            result.AppendLine($"User: {user.FirstName} {user.LastName}");

            var bankAccounts = user.BankAccounts;

            if (bankAccounts.Any())
            {
                result.AppendLine("Bank Accounts:");
            }

            foreach (var bankAccount in bankAccounts)
            {
                result.AppendLine($"-- ID: {bankAccount.BankAccountId}");
                result.AppendLine($"--- Balance: {bankAccount.Balance:F2}");
                result.AppendLine($"--- Bank: {bankAccount.BankName}");
                result.AppendLine($"--- SWIFT: {bankAccount.SwiftCode}");
            }

            var creditCards = user.CreditCards;

            if (creditCards.Any())
            {
                result.AppendLine("Credit Cards:");
            }

            foreach (var creditCard in creditCards)
            {
                result.AppendLine($"-- ID: {creditCard.CreditCardId}");
                result.AppendLine($"--- Limit: {creditCard.Limit}");
                result.AppendLine($"--- Money Owed: {creditCard.MoneyOwed}");
                result.AppendLine($"--- Limit Left:: {creditCard.LimitLeft}");
                result.AppendLine($"--- Expiration Date: {creditCard.ExpirationDate:yyyy/MM}");
            }

            return result.ToString().TrimEnd();
        }
    }
}

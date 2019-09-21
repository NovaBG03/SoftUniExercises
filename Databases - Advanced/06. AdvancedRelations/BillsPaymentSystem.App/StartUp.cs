namespace BillsPaymentSystem.App
{
    using System;

    using Models;
    using Models.Enums;
    using Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new BillsPaymentSystemContext())
            {
                //SeedDatabase(context);
            }
        }

        private static void SeedDatabase(BillsPaymentSystemContext context)
        {
            PaymentMethod[] paymentMethods =
            {
                new PaymentMethod
                {
                    User = new User
                    {
                        FirstName = "Ivan",
                        LastName = "Gogov",
                        Email = "ivancho@abv.bg",
                        Password = "ivan123"
                    },
                    PaymentType = PaymentType.BankAccount,
                    BankAccount = new BankAccount
                    {
                        Balance = 120,
                        BankName = "Random Bank",
                        SwiftCode = "RDBank123"
                    },
                    CreditCard = null
                },
                new PaymentMethod
                {
                    User = new User
                    {
                        FirstName = "Tosho",
                        LastName = "Toshev",
                        Email = "tosho@toshev.me",
                        Password = "toskata123"
                    },
                    PaymentType = PaymentType.BankAccount,
                    BankAccount = new BankAccount
                    {
                        Balance = 111110,
                        BankName = "Random Bank",
                        SwiftCode = "RDBank124"
                    },
                    CreditCard = null
                },
                new PaymentMethod
                {
                    User = new User
                    {
                        FirstName = "Petur",
                        LastName = "Sevliev",
                        Email = "malkiqgolqm@gmail.com",
                        Password = "igata123"
                    },
                    PaymentType = PaymentType.BankAccount,
                    BankAccount = new BankAccount
                    {
                        Balance = 12,
                        BankName = "Shitty Bank",
                        SwiftCode = "ShittyBank123"
                    },
                    CreditCard = null
                },
                new PaymentMethod
                {
                    User = new User
                    {
                        FirstName = "Vasil",
                        LastName = "Mendeleev",
                        Email = "tablica@abv.bg",
                        Password = "himiqobicham112"
                    },
                    PaymentType = PaymentType.BankAccount,
                    BankAccount = new BankAccount
                    {
                        Balance = 5,
                        BankName = "Shitty Bank",
                        SwiftCode = "ShittyBank124"
                    },
                    CreditCard = null
                },
                new PaymentMethod
                {
                    User = new User
                    {
                        FirstName = "Misho",
                        LastName = "Zvezdev",
                        Email = "kuhnq@btv.bg",
                        Password = "cherpak11"
                    },
                    PaymentType = PaymentType.BankAccount,
                    BankAccount = new BankAccount
                    {
                        Balance = 50,
                        BankName = "Shitty Bank",
                        SwiftCode = "ShittyBank125"
                    },
                    CreditCard = null
                },
                new PaymentMethod
                {
                    User = new User
                    {
                        FirstName = "Pencho",
                        LastName = "Penchev",
                        Email = "patki@abv.bg",
                        Password = "ferma123"
                    },
                    PaymentType = PaymentType.CreditCard,
                    BankAccount = null,
                    CreditCard = new CreditCard
                    {
                        Limit = 100000,
                        MoneyOwed = 100,
                        ExpirationDate = new DateTime(2040, 11, 1)
                    }
                },
                new PaymentMethod
                {
                    User = new User
                    {
                        FirstName = "Zdravko",
                        LastName = "Jelev",
                        Email = "zdravko_j@abv.bg",
                        Password = "zdravkojelev2004"
                    },
                    PaymentType = PaymentType.CreditCard,
                    BankAccount = null,
                    CreditCard = new CreditCard
                    {
                        Limit = 1200,
                        MoneyOwed = 200,
                        ExpirationDate = new DateTime(2042, 4, 15)
                    }
                },
                new PaymentMethod
                {
                    User = new User
                    {
                        FirstName = "Ivan",
                        LastName = "Gogov",
                        Email = "gogovivan@gmail.com",
                        Password = "gogoviV221"
                    },
                    PaymentType = PaymentType.CreditCard,
                    BankAccount = null,
                    CreditCard = new CreditCard
                    {
                        Limit = 10,
                        MoneyOwed = 2,
                        ExpirationDate = new DateTime(2040, 12, 1)
                    }
                },
                new PaymentMethod
                {
                    User = new User
                    {
                        FirstName = "Sasho",
                        LastName = "Uchev",
                        Email = "ushev@mail.com",
                        Password = "sashoushite67"
                    },
                    PaymentType = PaymentType.CreditCard,
                    BankAccount = null,
                    CreditCard = new CreditCard
                    {
                        Limit = 10000,
                        MoneyOwed = 9990,
                        ExpirationDate = new DateTime(2040, 2, 20)
                    }
                }
            };

            context.PaymentMethods.AddRange(paymentMethods);

            context.SaveChanges();
        }
    }
}

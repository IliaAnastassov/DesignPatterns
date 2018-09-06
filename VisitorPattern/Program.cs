using System;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.BankAccounts.Add(new BankAccount { Amount = 2000, MonthlyInterest = 0.01 });
            person.BankAccounts.Add(new BankAccount { Amount = 3500, MonthlyInterest = 0.02 });
            person.RealEstates.Add(new RealEstate { EstimatedValue = 120000, MonthlyRent = 1000 });
            person.Loans.Add(new Loan { AmountOwed = 50000, MonthlyPayment = 600 });

            decimal netWorth = 0;

            foreach (var bankAccount in person.BankAccounts)
            {
                netWorth += bankAccount.Amount;
            }

            foreach (var realEstate in person.RealEstates)
            {
                netWorth += realEstate.EstimatedValue;
            }

            foreach (var loan in person.Loans)
            {
                netWorth -= loan.AmountOwed;
            }

            Console.WriteLine(netWorth);
        }
    }
}

using System;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.Assets.Add(new BankAccount { Amount = 2000, MonthlyInterest = 0.01 });
            person.Assets.Add(new BankAccount { Amount = 3500, MonthlyInterest = 0.02 });
            person.Assets.Add(new RealEstate { EstimatedValue = 120000, MonthlyRent = 1000 });
            person.Assets.Add(new Loan { AmountOwed = 50000, MonthlyPayment = 600 });

            var netWorthVisitor = new NetWorthVisitor();
            var monthlyIncomeVisitor = new MonthlyIncomeVisitor();
            person.Accept(netWorthVisitor);
            person.Accept(monthlyIncomeVisitor);

            Console.WriteLine(netWorthVisitor.Amount);
            Console.WriteLine(monthlyIncomeVisitor.Amount);
        }
    }
}

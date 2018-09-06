using System.Collections.Generic;

namespace VisitorPattern
{
    public class Person
    {
        public Person()
        {
            BankAccounts = new List<BankAccount>();
            RealEstates = new List<RealEstate>();
            Loans = new List<Loan>();
        }

        public List<BankAccount> BankAccounts { get; set; }
        public List<RealEstate> RealEstates { get; set; }
        public List<Loan> Loans { get; set; }
    }

    public class BankAccount
    {
        public decimal Amount { get; set; }
        public double MonthlyInterest { get; set; }
    }

    public class RealEstate
    {
        public decimal EstimatedValue { get; set; }
        public decimal MonthlyRent { get; set; }
    }

    public class Loan
    {
        public decimal AmountOwed { get; set; }
        public decimal MonthlyPayment { get; set; }
    }
}

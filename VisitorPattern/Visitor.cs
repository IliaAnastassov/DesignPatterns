using System.Collections.Generic;

namespace VisitorPattern
{
    public interface IVisitor
    {
        void Visit(BankAccount bankAccount);
        void Visit(RealEstate realEstate);
        void Visit(Loan loan);
    }

    public class NetWorthVisitor : IVisitor
    {
        public decimal Amount { get; set; }

        public void Visit(BankAccount bankAccount)
        {
            Amount += bankAccount.Amount;
        }

        public void Visit(RealEstate realEstate)
        {
            Amount += realEstate.EstimatedValue;
        }

        public void Visit(Loan loan)
        {
            Amount -= loan.AmountOwed;
        }
    }

    public class MonthlyIncomeVisitor : IVisitor
    {
        public decimal Amount { get; set; }

        public void Visit(BankAccount bankAccount)
        {
            Amount += bankAccount.Amount * (decimal)bankAccount.MonthlyInterest;
        }

        public void Visit(RealEstate realEstate)
        {
            Amount += realEstate.MonthlyRent;
        }

        public void Visit(Loan loan)
        {
            Amount -= loan.MonthlyPayment;
        }
    }

    public interface IAsset
    {
        void Accept(IVisitor visitor);
    }

    public class Person
    {
        public Person()
        {
            Assets = new List<IAsset>();
        }

        public List<IAsset> Assets { get; set; }

        public void Accept(IVisitor visitor)
        {
            foreach (var asset in Assets)
            {
                asset.Accept(visitor);
            }
        }
    }

    public class BankAccount : IAsset
    {
        public decimal Amount { get; set; }
        public double MonthlyInterest { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class RealEstate : IAsset
    {
        public decimal EstimatedValue { get; set; }
        public decimal MonthlyRent { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Loan : IAsset
    {
        public decimal AmountOwed { get; set; }
        public decimal MonthlyPayment { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

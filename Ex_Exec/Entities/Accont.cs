using System;
using System.Collections.Generic;
using System.Linq;
using Ex_Exec.Entities.Exceptions;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Exec.Entities
{
    internal class Accont
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithDrawLimit { get; set; }

        public Accont()
        {
        }

        public Accont(int number, string holder, double balance, double withDrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithDrawLimit = withDrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount  ;
        }

        public void Withdraw(double amount)
        {
            if (WithDrawLimit < amount)
            {
                throw new DomainException("The amount exceeds withdraw limit");
            }
            if (Balance < amount)
            {
                throw new DomainException("Not enough balance");
            }

            Balance -= amount;
        }

        public override string ToString()
        {
            return "New balance: " + Balance.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}

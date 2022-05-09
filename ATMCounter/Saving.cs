using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCounter
{
    class Saving : Account
    {
        private int numberNIP;
        private int numberAccount;
        private double balanceAccount;

        Random randomNumber = new Random();
        public Saving(int _numberNIP)
        {
            numberNIP = _numberNIP;
            numberAccount = randomNumber.Next(10000000, 99999999);
            balanceAccount = 0;
        }


        public int NumberNIP => numberNIP;

        public int NumberAccount => numberAccount;

        public double BalanceAccount => balanceAccount;


        public double Deposit(double amount)
        {
            return (balanceAccount += amount);
        }

        public double WithDrawal(double amount)
        {
            return (balanceAccount -= amount);
        }

        public void PayInterest(float _interestRate)
        {
                balanceAccount = balanceAccount * (1 + _interestRate);
        }
    }
}


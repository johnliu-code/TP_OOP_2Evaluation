using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;

namespace ATMCounter
{
    class Checking : Account
    {
        private int numberNIP;
        private readonly int numberAccount;
        private double balanceAccount;


        Random randomNumber = new Random();

        public Checking(int _numberNIP)
        {
            numberNIP = _numberNIP;
            numberAccount = randomNumber.Next(10000000, 99999999);
            balanceAccount = 0;
        }
        public double UpdateBlance(double _balanceAccount)
        {
            return _balanceAccount;
        }

        public int NumberNIP => numberNIP;

        public int NumberAccount => numberAccount;

        public double BalanceAccount => balanceAccount;

        public double Deposit(double amount)
        {
            return balanceAccount += amount;
        }

        public double WithDrawal(double amount)
        {
            return balanceAccount -= amount;
        }

    }
}

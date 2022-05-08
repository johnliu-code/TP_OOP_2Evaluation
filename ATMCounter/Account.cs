using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCounter
{
    interface Account
    {
        int NumberNIP { get; }
        int NumberAccount { get; }
        double BalanceAccount { get; }
        double WithDrawal(double amount);
        double Deposit(double amount);
    }
}
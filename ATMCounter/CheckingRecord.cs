using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCounter
{
    class CheckingRecord
    {
        private double deposit;
        public double withdrawal;
        private DateTime transtime;
        private Checking checking;
        private double balance;

        public double Withdrawal { get; set; }
        public double Deposit { get; set; }
        public double Balance() { return balance; }
        public DateTime TransTime { get; }
        public Checking CheckingInfo() { return checking; }

        public CheckingRecord(Checking _checking) {
            checking = _checking;
            transtime = DateTime.Now;
            balance = _checking.BalanceAccount;
        }
    }
}

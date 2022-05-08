using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCounter
{
    class SavingRecord
    {
        private double deposit;
        public double withdrawal;
        private DateTime transtime;
        private Saving saving;
        private double balance;


        public double Withdrawal { get; set; }
        public double Deposit { get; set; }
        public double Balance() { return balance; }
        public DateTime TransTime { get; }
        public Saving SavingInfo() { return saving; }

        public SavingRecord(Saving _saving)
        {
            saving = _saving;
            transtime = DateTime.Now;
            balance = _saving.BalanceAccount;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCounter
{
    class Counter
    {
        private bool validUser;
        private double balance;

        public User user;
        public Checking checking;
        public Saving saving;

        public CheckingRecord checkingRecord;
        public SavingRecord savingRecord;

        public bool Validuser { get; }
        public double Balance { get; }
        public User User { get; }
        public Checking Checking { get; }
        public Saving Saving { get; }

        public CheckingRecord GetCheckingRecord { get; }
        public SavingRecord GetSavingRecord { get; }

        public Counter(User _user, Checking _checking, Saving _saving, CheckingRecord _checkingRecord, SavingRecord _savingRecord)
        {
           user = _user;
           checking = _checking;
           saving = _saving;
           savingRecord = _savingRecord;
           checkingRecord = _checkingRecord;
           validUser = true;
        }

        public Counter(User _user)
        {
            user = _user;
            checking = new Checking(_user.GetPinNumber());
            saving = new Saving(_user.GetPinNumber());
            checkingRecord = new CheckingRecord(checking);
            savingRecord = new SavingRecord(saving);
            validUser = true;
        }

        
        List<CheckingRecord> checking_records = new List<CheckingRecord>();
        List<SavingRecord> saving_records = new List<SavingRecord>();

        //Initialize and create user accounts list, checking accounts list, saving account list, records list.
        public void InitializeCounter()
        {
            if (user != null)
            {
                checking_records.Add(checkingRecord);
                saving_records.Add(savingRecord);
            }
            Console.WriteLine("----------------------------------------------\n" +
                               "    Your Bank Account Created success. \n" +
                              $"    User Name: {user.GetUserName()} \n" + 
                              $"    with PIN Number : {user.GetPinNumber()} \n" +
                               "    Please keep your Username and PIN safely!!! \n" +
                              "-----------------------------------------------");
        }

        //Checking Account whithdrawal and Deposit
    
        public double CheckingDeposit(int pinnumber, double amount)
        {
            if (validUser && amount > 0)
            {
                balance = checking.Deposit(amount);

                CheckingRecord checkingrecord = new CheckingRecord(checking);
                checkingrecord.Deposit = amount;

                checking_records.Add(checkingrecord);
                Console.WriteLine($"    Deposit {amount} to Checking has done success, new balnce: {balance}");
            }

            return balance;
         }

        public double CheckingWithdrawal(int pinnumber, double amount)
        {
            if (validUser && amount > 0)
            {
                if (amount < saving.BalanceAccount)
                {
                    if (amount <= 1000)
                    {
                        if (amount % 10 == 0)
                        {
                            balance = checking.WithDrawal(amount);

                            CheckingRecord checkingrecord = new CheckingRecord(checking);
                            checkingrecord.Withdrawal = amount;

                            checking_records.Add(checkingrecord);
                            Console.WriteLine($"    Withdrawal {amount} from Checking has done success, new balnce: {balance}");
                        }
                        else
                        {
                            Console.WriteLine("    Only allow at least 10$ dollar bills");
                        }
                    }
                    else
                    {
                        Console.WriteLine("    The Maximum amount is 1000$ / time");
                    }
                }
                else
                {
                    Console.WriteLine("    The Saving balance is not Enough for this Amount!!");
                }

            }

            return balance;
        }

        //Saving Account whithdrawal and Deposit

        public double SavingDeposit(int pinnumber, double amount)
        {
            if (validUser && amount > 0)
            {
                balance = saving.Deposit(amount);

                SavingRecord savingrecord = new SavingRecord(saving);;
                savingrecord.Deposit = amount;

                saving_records.Add(savingrecord);
                Console.WriteLine($"    Deposit {amount} to Saving has done success, new balnce: {balance}");
            }

            return balance;
        }

        public double SavingWithdrawal(int pinnumber, double amount)
        {

            if (validUser && amount > 0)
            {
                if (amount < checking.BalanceAccount)
                {
                    if (amount <= 1000)
                    {
                        if ( amount % 10 == 0)
                        {
                            balance = saving.WithDrawal(amount);

                            SavingRecord savingrecord = new SavingRecord(saving);
                            savingrecord.Withdrawal = amount;

                            saving_records.Add(savingrecord);
                            Console.WriteLine($"    Withdrawal {amount} from Saving has done success, new balnce: {balance}");
                        }
                        else
                        {
                            Console.WriteLine("    Only allow at least 10$ dollar bills");
                        }
                    }
                    else
                    {
                        Console.WriteLine("    The Maximum amount is 1000$ / time");
                    }
                }
                else
                {
                    Console.WriteLine("    The Cheking balance is not Enough for this Amount!!");
                }
            }

            return balance;

        }

        //Transfer from account
        public void TransferBetweenAccount (int pinnumber, double amount)
        {
            if (validUser && amount > 0 && amount <= 1000)
            {
                string message = "-------------------------------" +
                                  "\nSelect Transfer mode: " +
                                  "\n1.From Checking to Saving, " +
                                  "\n2. From Saving to Checking: " +
                                  "\nPlease entre Number 1 OR 2" +
                                  "\n------------------------------";
                int Option = 0;
                Option = Methods.ValidInt(Option, message);

                switch (Option)
                {
                    case 1:
                        if (amount <= checking.BalanceAccount)
                        {
                            Console.WriteLine("-------------------------------------------\n" +
                                               "    Tansfer from your checking account: \n" +
                                              $"    {checking.NumberAccount} \n" +
                                               "    to saving account : \n" +
                                              $"    {saving.NumberAccount} \n" +
                                              $"    Amount to transfer: {amount} \n" +
                                              "--------------------------------------------");

                            CheckingWithdrawal(pinnumber, amount);
                            SavingDeposit(pinnumber, amount);
                            Console.WriteLine("-------------------------------------------\n" +
                                              "    Transfer from Checking to Saving Account \n" +
                                             $"    with amount: {amount} is success! \n" +
                                              "-------------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("---------------------------------------\n" +
                                             $"    Checking Account balance : {checking.BalanceAccount} \n" +
                                              "    Your account blance is not enough!! \n" +
                                             "-----------------------------------------");
                        }

                        break;

                    case 2:

                        if (amount <= saving.BalanceAccount)
                        {
                            Console.WriteLine("-------------------------------------------\n" +
                                              "    Tansfer from your saving account: \n" +
                                             $"    {saving.NumberAccount} \n" +
                                              "    to checking account : \n" +
                                             $"    {checking.NumberAccount} \n" +
                                             $"    Amount to transfer: {amount} \n" +
                                              "--------------------------------------------");

                            SavingWithdrawal(pinnumber, amount);
                            CheckingDeposit(pinnumber, amount);
                            Console.WriteLine("-------------------------------------------\n" +
                                              "    Transfer from Saving to Checking Account \n" +
                                             $"    with amount: {amount} is success! \n" +
                                              "-------------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("---------------------------------------\n" +
                                             $"    Saving Account balance : {saving.BalanceAccount} \n" +
                                              "    Your account blance is not enough!! \n" +
                                             "-----------------------------------------");
                        }

                        break;

                    default:
                        Console.WriteLine("    Please entre valid number 1 or 2");
                        break;
                }
            }
        }

        //Display records

        public void DisplayCheckingInfo(User _user)
        {
            for (int i = 0; i < checking_records.Count; i++)
            {
                if (checking_records[i].CheckingInfo().NumberAccount == checking.NumberAccount)
                    Console.WriteLine("------------------------------------------------------\n" +
                                     $"    Checking Records for {_user.GetUserName()} : \n" +
                                     $"    Account Number: {checking_records[i].CheckingInfo().NumberAccount} \n" +
                                     $"    Withdrawal: {checking_records[i].Withdrawal} \n" +
                                     $"    Deposit: {checking_records[i].Deposit} \n" +
                                     $"    Trans Time: {checking_records[i].TransTime} \n" +
                                     $"    Account Balance: {checking_records[i].Balance()} \n" +
                                      "------------------------------------------------------");
            }
        }

        public void DisplaySavingInfo(User _user)
        {
            for (int i = 0; i < saving_records.Count; i++)
            {
                if (saving_records[i].SavingInfo().NumberAccount == saving.NumberAccount)
                    Console.WriteLine("------------------------------------------------------\n" +
                                     $"    Saving Records for { _user.GetUserName()} : \n" +
                                     $"    Account Number: {saving_records[i].SavingInfo().NumberAccount} \n" +
                                     $"    Withdrawal: {saving_records[i].Withdrawal} \n" +
                                     $"    Deposit: {saving_records[i].Deposit} \n" +
                                     $"    Trans Time: {saving_records[i].TransTime} \n" +
                                     $"    Account Balance: {saving_records[i].Balance()} \n" +
                                      "------------------------------------------------------");
            }
        }
        
    }
}

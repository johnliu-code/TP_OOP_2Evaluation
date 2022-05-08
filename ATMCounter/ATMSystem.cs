using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCounter
{
    class ATMSystem
    {
        private bool validUser;

        User user;
        Saving saving;
        Checking checking;
        Counter counter;

        public bool ValidUser { get; set; }
 

        public void SetCounter(Counter counter) { this.counter = counter; }

        List<User> users = new List<User>();
        List<Saving> savingAccounts = new List<Saving>();
        List<Checking> checkingAccounts = new List<Checking>();
        Dictionary<int, Counter> clientCounters = new Dictionary<int, Counter>();


        //Validate user and loged in.
        public User ValidateUser(string username, int pinnumber)
        {
            for (int i = 0; i < 3;)
            {
                Console.WriteLine("    User Name: ");
                username = Console.ReadLine();
                Console.WriteLine("    PIN Number:");
                pinnumber = Methods.ValidInt(pinnumber, "    Please entre your PIN Number");

                foreach (User v_user in users)
                {
                    if (v_user.GetUserName() == username && v_user.GetPinNumber() == pinnumber)
                    {
                        Console.WriteLine("-----------------------------------\n" +
                                          $"     User Name: {username}\n" +
                                           "     You are already Loged in!!\n" +
                                          "-----------------------------------");

                        i = 3;
                        ValidUser = true;
                        counter = GetCounter(v_user.GetPinNumber());
                        user = v_user;
  
                    }
                    else
                    {
                        validUser = false;
                    }
                }
                if (!validUser && i < 3)
                {
                    i++;
                    Console.WriteLine("-----------------------------------\n" +
                                     "    Username or PIN Number is invalid \n" + 
                                    $"    you have {3 - i} more time to try it!! \n" +
                                      "-----------------------------------");
                }
                else { break; }

            }
            
            return user;
        }

        //ATM System Initialize, Create Users and Thier Counters Records.
        public void ATMInitial(User _user, Counter _counter)
        {
            users.Add(_user);
            clientCounters.Add(_user.GetPinNumber(),_counter);

            saving = _counter.saving;
            savingAccounts.Add(saving);

            checking = _counter.checking;
            checkingAccounts.Add(checking);
        }
        public void AdminInitial(User _user)
        {
            users.Add(_user);
        }


        // Get user accounts from list

        public User FindUser(int pinnumber)
        {
            foreach (var f_user in users)
            {
                if (f_user.GetPinNumber() == pinnumber)
                    user = f_user;
            }

            return user;
        }

        public Counter GetCounter(int pinnumber)
        {
            foreach (var record in clientCounters)
            {
                if (record.Key == pinnumber )
                {
                    counter = record.Value;
                }
            }
            return counter;
        }

        public void DisplayUsers()
        {
            Console.Clear();
            
            Console.WriteLine("\n        Test Users info:       "); 
            foreach (var _user in users)
            {
            Console.WriteLine("--------------------------------------\n" +
                              $"    First Name: {_user.GetFirstname()},\n" + 
                              $"    Last Name: {_user.GetLastname()},\n" +
                              $"    UserName: {_user.GetUserName()},\n" +
                              $"    PIN Number: {_user.GetPinNumber()}\n" +
                              "--------------------------------------");
            }
            Console.WriteLine("Please take note of Username and PIN for testing!!! \nTab any KEY to continue!!");
            Console.ReadKey(true);
            Console.Clear();
        }

        //Administrators actions
        public void PayClientSavingInterest(User _user)                      //Pay client saving accout interest
        {
            
            if (ValidUser && _user.GetUserType() == 0)
            {
                float interestrate = 0.0125F;

                Console.WriteLine("-------------------------------------\n" +
                                 $"    Pay rate of: {interestrate} \n" + 
                                  "    to all Saving accounts? Y/N \n" +
                                  "-------------------------------------");
                string answer = Console.ReadLine().ToUpper();

                switch (answer)
                {
                    case "Y":
                        foreach (var savingaccount in savingAccounts)
                        {
                            savingaccount.PayInterest(interestrate);
                        }
                        break;
                    case "N":
                        Console.WriteLine("-------------------------------------------\n" +
                                          "    New interest rate: (0.00001 - 0.09)\n" +
                                          "    For all of client saving account:\n" +
                                          "-------------------------------------------");
                        float interst = float.Parse(Console.ReadLine());
                        foreach (var savingaccount in savingAccounts)
                        {
                            savingaccount.PayInterest(interst);
                        }
                        break;
                    default:
                        Console.WriteLine("    Please entre valid letter Y or N");
                        break;
                }

            }
            else
            {
                Console.WriteLine("    You are not a valid user!!");
            }
            Console.WriteLine("    The interst payment to all saving account success!!");

        }

        //Generate client account reports
        public void AccountReport(User _user)
        {
            if (ValidUser && _user.GetUserType() == 0)
            {
                foreach (var savingaccount in savingAccounts)
                {
                    Console.WriteLine("---------------------------------------------------\n" +
                                     $"    Saving account number: {savingaccount.NumberAccount}\n" + 
                                     $"    Saving account balance: {savingaccount.BalanceAccount}\n" +
                                     $"    Report Date: {DateTime.Now}\n" +
                                      "---------------------------------------------------");
                }

                foreach (var checkingaccount in checkingAccounts)
                {
                    Console.WriteLine("---------------------------------------------------\n" +
                                     $"    Checking account number: {checkingaccount.NumberAccount} \n" +
                                     $"    Checking account balance: {checkingaccount.BalanceAccount} \n" +
                                     $"    Report Date: {DateTime.Now} \n" +
                                      "---------------------------------------------------");
                }
            }

        }
    }
}

using System;
using System.Globalization;
using System.Collections.Generic;
using static System.Console;
using static System.Convert;

namespace ATMCounter
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ATM Counter Project for Evaluation 2.");
            Console.Clear();

            MainMenu();

        }

  
        // Menu and methods

        public static void MainMenu ()
        {
            string username = "";
            int pinnumber = 0;
            double amount = 0;
            bool userlogedin;
            bool is_admin;

            // Initialize users and counter for testing
            ATMSystem atm = new ATMSystem();

            User client1 = new Client("Yongjiang", "Liu", "LYJ6789");

            Counter counter1 = new Counter(client1);
            counter1.InitializeCounter();
            atm.ATMInitial(client1, counter1);

            User client2 = new Client("Mary", "Wang", "MW1234");

            Counter counter2 = new Counter(client2);
            counter2.InitializeCounter();
            atm.ATMInitial(client2, counter2);

            User admin1 = new Administrator("Tom", "Zhang", "Tom1234");
            atm.AdminInitial(admin1);
            atm.DisplayUsers();

            string backTomain = "Y";

            while (backTomain == "Y")
            {
                string message = "WelCome to ATM : 1. Login; 2. Log out.";
                int inputValue = 0;
                int mainMenuOption = Methods.ValidInt(inputValue, message);
                switch (mainMenuOption)
                {
                    case 1:

                        User loginUser = atm.ValidateUser(username, pinnumber);
                        userlogedin = atm.ValidUser;
                        Counter counter = atm.GetCounter(loginUser.GetPinNumber());

                        if (userlogedin && loginUser.GetUserType() == 1)
                        {
                            Console.WriteLine("Client");
                            string backToAccountMenu = "Y";

                            while (backToAccountMenu == "Y")
                            {
                                message = "Please choose your Menu option: 1. Deposit; 2. Withdrawl; 3. Transfer; 4.History, 5. Exit";
                                int subMenuOption = Methods.ValidInt(inputValue, message);
                                switch (subMenuOption)
                                {
                                    case 1:
                                        message = "Please chose Account Type you want to Deposit: 1. Cheking, 2. Saving.";
                                        int accountOption = Methods.ValidInt(inputValue, message);

                                        switch (accountOption)
                                        {
                                            case 1:
                                                message = "Please entre Amount you want to Deposit into Checking:";
                                                amount = Methods.ValidDouble(inputValue, message);
                                                counter.CheckingDeposit(loginUser.GetPinNumber(), amount);
                                                break;
                                            case 2:
                                                message = "Please entre Amount you want to Deposit into Saving:";
                                                amount = Methods.ValidDouble(inputValue, message);
                                                counter.SavingDeposit(loginUser.GetPinNumber(), amount);
                                                break;
                                            default:
                                                WriteLine("Please entre a int number between 1 to 2 !");
                                                break;
                                        }

                                        break;

                                    case 2:
                                        message = "Please chose Account Type you want to Withdrawal from: 1. Cheking, 2. Saving.";
                                        int account_type = Methods.ValidInt(inputValue, message);

                                        switch (account_type)
                                        {
                                            case 1:
                                                message = "Please entre Amount you want to Withdrawal from Checking:";
                                                amount = Methods.ValidDouble(inputValue, message);

                                                if (amount < counter.checking.BalanceAccount)
                                                {
                                                    if (amount < 1000 && amount % 10 == 0)
                                                    {
                                                        counter.CheckingWithdrawal(loginUser.GetPinNumber(), amount);
                                                    }
                                                    else
                                                    {
                                                        WriteLine("The Maximum amount is 1000, and must be 10 times bills");
                                                    }
                                                }
                                                else
                                                {
                                                    WriteLine("The Cheking account balance is not Enough for this Amount!!");
                                                }

                                                break;
                                            case 2:
                                                message = "Please entre Amount you want to Withdrawal from Saving:";
                                                amount = Methods.ValidDouble(inputValue, message);

                                                if (amount < counter.saving.BalanceAccount)
                                                {
                                                    if (amount < 1000 && amount % 10 == 0)
                                                    {
                                                        counter.SavingWithdrawal(loginUser.GetPinNumber(), amount);
                                                    }
                                                    else
                                                    {
                                                        WriteLine("The Maximum amount is 1000, and must be 10 times bills");
                                                    }
                                                }
                                                else
                                                {
                                                    WriteLine("The Saving account balance is not Enough for this Amount!!");
                                                }

                                                break;
                                            default:
                                                WriteLine("Please entre a int number between 1 to 2 !");
                                                break;

                                                WriteLine("Back to Main Menu? Y/N");
                                                backTomain = ReadLine().ToUpper();
                                        }

                                        break;

                                    case 3:
                                        message = "Please entre Amount you want to Transfer:";
                                        amount = Methods.ValidDouble(inputValue, message);

                                        counter.TransferBetweenAccount(loginUser.GetPinNumber(), amount);
                                        break;

                                    case 4:
                                        counter.DisplayCheckingInfo(loginUser);
                                        counter.DisplaySavingInfo(loginUser);
                                        break;

                                    case 5:
                                        userlogedin = false;
                                        backToAccountMenu = "N";
                                        break;

                                    default:
                                        WriteLine("Please entre a int number between 1 to 4 !");
                                        break;
                                }

                                WriteLine("Back to Account Menu? Y/N");
                                backToAccountMenu = ReadLine().ToUpper();
                            }

                        }
                        else if (userlogedin && loginUser.GetUserType() == 0)
                        {
                            Console.WriteLine("Admin");

                            string backtoAdminMenu = "Y";

                            while (backtoAdminMenu == "Y")
                            {
                                message = "Please choose your Menu option: 1. Pay Interest Rate; 2. Display Report; 3. Exit";
                                int adminOption = Methods.ValidInt(inputValue, message);

                                switch (adminOption)
                                {
                                    case 1:
                                        atm.PayClientSavingInterest(loginUser);
                                        break;

                                    case 2:
                                        atm.AccountReport(loginUser);
                                        break;

                                    default:
                                        WriteLine("Please entre Number between 1 and 3 !!!");
                                        break;
                                }

                                WriteLine("Back to Account Menu? Y/N");
                                backtoAdminMenu = ReadLine().ToUpper();
                            }


                        }

                        break;

                    case 2:

                        backTomain = "Y";
                        break;

                    default:
                        WriteLine("Please entre a int number between 1 to 2 !");
                        break;
                }
                WriteLine("Back to Main Menu? Y/N");
                backTomain = ReadLine().ToUpper();
            }
        }

    }
}

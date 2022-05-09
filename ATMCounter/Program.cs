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
            WriteLine("ATM Counter Project for Evaluation 2.");
            Clear();

            MainMenu();

        }

  
        // Menu and methods

        public static void MainMenu ()
        {
            string username = "";
            int pinnumber = 0;
            double amount = 0;
            bool userlogedin;

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
                string message = "       Main menu        \n" +
                                 "--------------------------\n" +
                                 "    WelCome to ATM : \n" +
                                 "    1. Login  \n" +
                                 "    2. Exit \n" +
                                 "---------------------------";
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
                            Clear();
                            WriteLine($"    Welcome Client: {loginUser.GetFirstname()} !!");
                            string backToAccountMenu = "Y";

                            while (backToAccountMenu == "Y")
                            {
                                Clear();
                                message = "--------------------------------------- \n" +
                                          "    Please choose your Menu option: \n" +
                                          "    1. Deposit \n" +
                                          "    2. Withdrawl \n" +
                                          "    3. Transfer \n" +
                                          "    4. History \n" +
                                          "    5. Exit \n" +
                                          "---------------------------------------";
                                int subMenuOption = Methods.ValidInt(inputValue, message);
                                switch (subMenuOption)
                                {
                                    case 1:
                                        Clear();
                                        message = "--------------------------------------------- \n" +
                                                  "     Which Account you want to Deposit: \n" +
                                                  "     1. Cheking \n" +
                                                  "     2. Saving \n" +
                                                  "---------------------------------------------";
                                        int accountOption = Methods.ValidInt(inputValue, message);

                                        switch (accountOption)
                                        {
                                            case 1:
                                                Clear();
                                                message = "---------------------------------------- \n" +
                                                          "    Amount to Deposit into Checking: \n" +
                                                          "----------------------------------------";
                                                amount = Methods.ValidDouble(inputValue, message);
                                                counter.CheckingDeposit(loginUser.GetPinNumber(), amount);
                                                break;
                                            case 2:
                                                Clear();
                                                message = "---------------------------------------- \n" +
                                                          "    Amount to Deposit into Saving: \n" + 
                                                          "----------------------------------------";
                                                amount = Methods.ValidDouble(inputValue, message);
                                                counter.SavingDeposit(loginUser.GetPinNumber(), amount);
                                                break;
                                            default:
                                                WriteLine("    Please entre a int number between 1 to 2 !");
                                                break;
                                        }

                                        break;

                                    case 2:
                                        Clear();
                                        message = "------------------------------------------ \n" +
                                                  "    Which Account to Withdrawal from: \n" +
                                                  "    1. Cheking \n" +
                                                  "    2. Saving \n" +
                                                  "------------------------------------------";
                                        int account_type = Methods.ValidInt(inputValue, message);

                                        switch (account_type)
                                        {
                                            case 1:
                                                Clear();
                                                message = "--------------------------------------------- \n" +
                                                          "    Amount to Withdrawal from Checking: \n" +
                                                          "---------------------------------------------";
                                                amount = Methods.ValidDouble(inputValue, message);

                                                counter.CheckingWithdrawal(loginUser.GetPinNumber(), amount);

                                                break;
                                            case 2:
                                                Clear();
                                                message = "------------------------------------------ \n" +
                                                          "    Amount to Withdrawal from Saving: \n" +
                                                          "------------------------------------------";
                                                amount = Methods.ValidDouble(inputValue, message);

                                                counter.SavingWithdrawal(loginUser.GetPinNumber(), amount);

                                                break;
                                            default:
                                                WriteLine("    Please entre a int number between 1 to 2 !");
                                                break;
                                        }

                                        break;

                                    case 3:
                                        Clear();
                                        message = "---------------------------- \n" +
                                                  "    Amount to Transfer: \n" +
                                                  "----------------------------";

                                        double maxvalue = 1000;
                                        amount = Methods.MaxValue(amount, message, maxvalue);

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
                                        WriteLine("    Please entre a int number between 1 to 4 !");
                                        break;
                                }

                                WriteLine("    Back to Account Menu? Y/N");
                                backToAccountMenu = ReadLine().ToUpper();
                            }

                        }
                        else if (userlogedin && loginUser.GetUserType() == 0)
                        {
                            Clear();
                            WriteLine($"    Welcome Aministrator: { loginUser.GetFirstname()}!!");

                            string backtoAdminMenu = "Y";

                            while (backtoAdminMenu == "Y")
                            {
                                Clear();
                                message = "-------------------------------------- \n" +
                                          "    Please choose your Menu option: \n" +
                                          "    1. Pay Interest Rate \n" +
                                          "    2. Display Report \n" +
                                          "    3. Exit \n" +
                                          "--------------------------------------";
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
                                        WriteLine("    Please entre Number between 1 and 3 !!!");
                                        break;
                                }

                                WriteLine("    Back to Account Menu? Y/N");
                                backtoAdminMenu = ReadLine().ToUpper();
                            }

                        }

                        break;

                    case 2:

                        backTomain = "Y";
                        break;

                    default:
                        WriteLine("    Please entre a int number between 1 to 2 !");
                        break;
                }
                WriteLine("    Back to Main Menu? Y/N");
                backTomain = ReadLine().ToUpper();
            }
        }

    }
}
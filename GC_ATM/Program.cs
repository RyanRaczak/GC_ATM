using System;

namespace GC_ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM myAtm = new ATM();
            bool userContinue = true;
            string input, userName, userPass;
            decimal money;
            Console.WriteLine("\n::::Welcome to Ryan Financial::::");
            while (userContinue)
            {
                Console.WriteLine($"\n\nCurrent User: \n{myAtm.currentUser}\n" +
                    $"\n::Main Menu::");
                input = GetInput("\n1) Register" +
                    "\n2) Login" +
                    "\n3) Logout" +
                    "\n4) Check Balance" +
                    "\n5) Deposit" +
                    "\n6) Withdraw" +
                    "\n7) Display Info(for testing)" +
                    "\n8) Exit" +
                    "\n:: ");
                switch (input)
                {
                    case "1": //Register
                        userName = GetInput("\nPlease enter a username to register: ");
                        userPass = GetInput("\nPlease enter a password to register: ");
                        myAtm.Register(userName, userPass);
                        Console.WriteLine($"\n{userName} has been registered");
                        break;

                    case "2": //Login
                        userName = GetInput("\nPlease enter your username: ");
                        userPass = GetInput("\nPlease enter your password: ");
                        myAtm.Login(userName, userPass);
                        break;

                    case "3": //Logout
                        myAtm.LogOut();
                        break;

                    case "4": //Check Balance
                        myAtm.CheckBalance();
                        break;

                    case "5": //Deposit
                        if (myAtm.loggedIn)
                        {
                            money = GetMoney();
                            myAtm.Deposit(money);
                        }
                        else
                        {
                            Console.WriteLine("\nYou must be logged in to use this function");
                        }
                        break;

                    case "6": //Withdraw
                        if (myAtm.loggedIn)
                        {
                            money = GetMoney();
                            myAtm.Withdraw(money);
                        }
                        else
                        {
                            Console.WriteLine("\nYou must be logged in to use this function");
                        }
                        break;

                    case "7": //Display DB
                        myAtm.DisplayInfo();
                        break;

                    case "8": //Exit
                        userContinue = false;
                        Console.WriteLine("\nGoodbye...");
                        break;

                    default:  //Invalid input
                        Console.WriteLine("\nInvalid input...");
                        break;
                }
            }
        }

        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine().ToLower();
        }
        public static decimal GetMoney()
        {
            decimal money;
            string input = GetInput("\nPlease enter the amount: ");
            if (decimal.TryParse(input, out money))
            {
                return money;
            }
            else
            {
                Console.WriteLine("Invalid input...");
                return GetMoney();
            }

        }
    }
}

using System;
using System.Collections.Generic;

namespace GC_ATM
{
    class ATM
    {
        public List<Account> accounts = new List<Account>();
        public bool loggedIn;
        public string currentUser;
        public int currentIndex;

        public ATM()
        {
            this.loggedIn = false;
            this.currentUser = "No User";
            this.currentIndex = -1;
            InitiateDatabase();
        }
        public void Register(string name, string pass)
        {
            accounts.Add(new Account(name, pass));
        }
        public void Login(string name, string pass)
        {
            //Check if someone is logged in
            if (loggedIn)
            {
                Console.WriteLine($"\nUser {currentUser} is logged in. Please log out.");
                return;
            }
            //Make sure accounts were added to DB
            else if (accounts.Count == 0)
            {
                Console.WriteLine("\nThere are no users in this database...");
                return;
            }
            //Finding account in DB to login
            else
            {
                for (int i = 0; i < accounts.Count; i++)
                {
                    if (accounts[i].AccountName == name && accounts[i].AccountPass == pass)
                    {
                        loggedIn = true;
                        currentUser = name;
                        currentIndex = i;
                        return;
                    }
                }
                if (currentIndex == -1)
                {
                    Console.WriteLine("\nEither your username or password was incorrect");
                }
            }
        }
        public void LogOut()
        {
            if (loggedIn)
            {
                Console.WriteLine($"\n{currentUser} has been logged out");
                loggedIn = false;
                currentIndex = -1;
                currentUser = "No User";
                return;
            }
            else
            {
                Console.WriteLine("\nYou must be logged in to use this function");
                return;
            }

        }
        public void CheckBalance()
        {
            if (loggedIn)
            {
                Console.WriteLine($"\nCurrent Ballance: {accounts[currentIndex].Balance:c}");
                return;
            }
            else
            {
                Console.WriteLine("\nYou must be logged in to use this function");
                return;
            }
        }
        public void Deposit(decimal depo)
        {
            if (loggedIn)
            {
                accounts[currentIndex].Balance += depo;
                Console.WriteLine($"\n{depo:c} has been added to your account");
                return;
            }
            else
            {
                Console.WriteLine("\nYou must be logged in to use this function");
                return;
            }
        }
        public void Withdraw(decimal withd)
        {
            if (loggedIn)
            {
                if (accounts[currentIndex].Balance < withd)
                {
                    Console.WriteLine($"\n{withd:c} is more than the current balance. Unable to withdraw.");
                    return;
                }
                else
                {
                    accounts[currentIndex].Balance -= withd;
                    Console.WriteLine($"\n{withd:c} has been withdrawn");
                    return;
                }
            }
            else
            {
                Console.WriteLine("\nYou must be logged in to use this function");
                return;
            }
        }
        public void InitiateDatabase()
        {
            accounts.Add(new Account("ryan", "1234"));
            accounts.Add(new Account("matt", "5678"));
            accounts.Add(new Account("ray", "4321"));
        }
        public void DisplayInfo()
        {
            Console.WriteLine("\n\n");
            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine($"Name: {accounts[i].AccountName}\tPass: {accounts[i].AccountPass}" +
                    $"\tBalance: {accounts[i].Balance:c}");
            }
            Console.WriteLine("\n\n");
        }

    }
}

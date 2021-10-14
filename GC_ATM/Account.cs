using System;
using System.Collections.Generic;
using System.Text;

namespace GC_ATM
{
    class Account
    {
        private string accountName;
        private string accountPass;
        private decimal balance = 0;

        public Account(string name, string pass)
        {
            this.accountName = name;
            this.accountPass = pass;
        }
        public string AccountName
        {
            get => accountName;
            set => accountName = value;
        }
        public string AccountPass
        {
            get => accountPass;
            set => accountPass = value;
        }
        public decimal Balance
        {
            get => balance;
            set => balance = value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using PersonDB.Models;
using PersonDB.Repositories;

namespace PersonDB.Views
{
    class AccountView
    {
        private AccountRepository accountRepository = new AccountRepository();
        public void AddTransaction()
        {
            Transaction transaction = new Transaction
            {
                Amount = -200,
                Iban = "FI4422772000035988",
                TimeStamp = DateTime.Now
            };
        }
    }
}


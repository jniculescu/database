using System;
using System.Collections.Generic;
using System.Text;
using PersonDB.Models;

namespace PersonDB.Repositories
{
    interface ITransaction
    {
        List<Transaction> GetAccountsTransactions();
        List<Transaction> GetAccountTransactions(string iban);
    }
}

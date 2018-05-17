using System;
using System.Collections.Generic;
using System.Text;
using PersonDB.Models;

namespace PersonDB.Repositories
{
    interface IAccount
    {
        void AddTransaction(Transaction transaction);
        List<Transaction> GetTransactionsForTimeSpan(DateTime startTime, DateTime endTime);
        List<Transaction> GetTransactionsForTimeSpan(string iban);
    }
}

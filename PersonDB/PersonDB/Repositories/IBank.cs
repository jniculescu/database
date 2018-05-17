using System;
using System.Collections.Generic;
using System.Text;
using PersonDB.Models;

namespace PersonDB.Repositories
{
    interface IBank
    {
        List<Bank> GetBanks();
        List<Bank> GetBankCustomers();
        List<Bank> GetBankAccounts();
        Bank GetBankById(long id);
        void Create(Bank bank);
        void Update(Bank bank);
        void Delete(int id);
        string CreateAccount();
        bool AddTransactionForCustomer(string accountNumber, Transaction transaction);
        double GetBalanceForCustomer(string accountNumber);    
        List<Transaction> GetTransactionsForCustomerForTimeSpan(string accountNumber,
            DateTime startTime, DateTime endTime);
    }
}

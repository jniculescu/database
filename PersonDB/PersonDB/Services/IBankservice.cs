using System;
using System.Collections.Generic;
using System.Text;
using PersonDB.Models;

namespace PersonDB.Services
{
    interface IBankService
    {
        List<Bank> GetBankCustomers();
        List<Bank> GetBankAccounts();
        List<Bank> GetBanks();
        Bank FindBankById(long id);
        void CreateBank(Bank bank);
        void UpdateBank(Bank bank);
        void DeleteBank(int id);
    }
}

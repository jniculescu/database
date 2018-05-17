using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PersonDB.Models;

namespace PersonDB.Repositories
{
    class AccountRepository : IAccount
    {
        public void AddTransaction(Transaction transaction)
        {
            using (var context = new Persondb2Context())
            {
                try
                { 
                    context.Add(transaction);
                    var account = GetAccountByIban(transaction.Iban);
                    account.Balance += transaction.Amount;

                    context.Account.Update(account);    
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }

            }
        }

        public Account GetAccountByIban(string iban)
        {
            using (var context = new Persondb2Context())
            {
                try
                {
                    var account = context.Account.FirstOrDefault(a => a.Iban == iban);
                    return account;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \nXXX");
                }
            }
        }

        public List<Transaction> GetTransactionsForTimeSpan(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetTransactionsForTimeSpan(string iban)
        {
            throw new NotImplementedException();
        }

        public Transaction GetTransactionsOfAccount(string iban)
        {
            using (var context = new Persondb2Context())
            {
                try
                {
                    var transaction = context.Transaction.Last(t => t.Iban == iban);
                    return transaction;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \nXXX");
                }
            }
        }
    }
}

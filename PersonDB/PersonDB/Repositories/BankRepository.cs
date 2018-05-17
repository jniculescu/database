using System;
using System.Collections.Generic;
using System.Text;
using PersonDB.Models;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PersonDB.Repositories
{
    class BankRepository : IBank
    {
        public List<Bank> GetBanks()
        {
            using (var context = new Persondb2Context())
            {
                try
                {
                    List<Bank> banks = context.Bank.ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }

            }
        }

        public List<Bank> GetBankCustomers()
        {
            using (var context = new Persondb2Context())
            {
                try
                {
                    List<Bank> banks = context.Bank
                        .Include(b => b.Customer)
                        .ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }

            }

        }

        public List<Bank> GetBankAccounts()
        {
            using (var context = new Persondb2Context())
            {
                try
                {
                    List<Bank> banks = context.Bank
                        .Include(b => b.Account)
                        .ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }
            }
        }

        public Bank GetBankById(long id)
        {
            using (var context = new Persondb2Context())
            {
                try
                {
                    var bank = context.Bank.FirstOrDefault(b => b.Id == id);
                    return bank;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \nXXX");
                }

            }
        }

        public void Create(Bank bank)
        {
            using (var context = new Persondb2Context())
            {
                try
                {
                    context.Add(bank);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \nXXX");
                }

            }

        }

        public void Update(Bank bank)
        {
            using (var context = new Persondb2Context())
            {
                try
                {
                    var updateBank = GetBankById(bank.Id);
                    if (updateBank != null)
                    {
                        updateBank.Name = bank.Name;
                        updateBank.Bic = bank.Bic;
                        context.Bank.Update(updateBank);
                    }
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \nXXX");
                }

            }
        }

        public void Delete(int id)
        {
            using (var context = new Persondb2Context())
            {
                try
                {
                    var delBank = context.Bank.FirstOrDefault(b => b.Id == id);
                    if (delBank != null)
                        context.Bank.Remove(delBank);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \nXXX");
                }

            }
        }

        public string CreateAccount()
        {
            throw new NotImplementedException();
        }

        public bool AddTransactionForCustomer(string accountNumber, Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public double GetBalanceForCustomer(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetTransactionsForCustomerForTimeSpan(string accountNumber, DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public List<Bank> GetTransactionsFromBankCustomersAccounts()
        {
            using (var context = new Persondb2Context())
            {
                try
                {
                    List<Bank> banks = context.Bank
                        .Include(b => b.Customer)
                        .Include(b => b.Account)
                        .Include(b => b.Account).ThenInclude(a => a.Transaction)
                        .Where(b=>b.Id==13)
                        .ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }    
            } 
        }
    }
}

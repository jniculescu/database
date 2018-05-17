using System;
using System.Collections.Generic;
using System.Text;
using PersonDB.Models;
using PersonDB.Services;

namespace PersonDB.Views
{
    class BankView
    {
        public void DeleteBank()
        {
            BankService bankService = new BankService();
            var banks = bankService.GetBanks();
            foreach (var b in banks)
            {
                Console.WriteLine(b.ToString());
            }
            Console.Write("Delete Bank - Select <ID>:");
            int id = int.Parse(Console.ReadLine());

            bankService.DeleteBank(id);
        }
        public void PrintAllBanks()
        {
            try
            {
                Console.WriteLine("List of all Banks-Customers-Accounts-Transactions");
                BankService bankService = new BankService();
                var bankCustomers = bankService.GetTransactionsFromBankCustomersAccounts();

                foreach (var bC in bankCustomers)
                {
                    Console.WriteLine(bC.ToString());
                    foreach (var c in bC.Customer)
                    {
                        Console.WriteLine(c.ToString());
                        foreach (var cAccount in c.Account)
                        {
                            Console.WriteLine($"\t{cAccount.ToString()}");
                            foreach (var trn in cAccount.Transaction)
                            {
                                Console.WriteLine($"\t{trn.ToString()}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreateBankCustomerAccount()
        {
            BankService bankService = new BankService();
            Bank bank = new Bank("Nordea", "BICNRD");
            Customer customer1 = new Customer("Nordea", "Nordea");
            Customer customer2 = new Customer("NordeaXX", "NordeaXX");

            List<Customer> customers = new List<Customer>();
            customers.Add(customer1);
            customers.Add(customer2);

            Account account1 = new Account("FI44 1236", "Säästötili", 3000);
            Account account2 = new Account("FI44 1237", "Käyttötili", 1000);
            List<Account> accounts = new List<Account>();
            accounts.Add(account1);
            accounts.Add(account2);

            Transaction transaction1 = new Transaction(350, new DateTime(2018, 04, 09));
            Transaction transaction2 = new Transaction(-50, new DateTime(2018, 04, 09));
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(transaction1);
            transactions.Add(transaction2);

            account1.Transaction = transactions;

            customer1.Account = accounts;

            bank.Customer = customers;
            bank.Account = accounts;

            bankService.CreateBank(bank);  
        }
    }
}

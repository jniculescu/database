using System;
using PersonDB.Views;
using PersonDB.Services;
using PersonDB.Models;

namespace PersonDB
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Nice Bank App 1.02");
                BankView bankView = new BankView();
                bankView.PrintAllBanks();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

        }

        public static void CreateBank()
        {
            BankService bankService = new BankService();
            Bank bank = new Bank();
            bank.Name = "Cool Bank";
            bank.Bic = "BICOOL";
            bankService.CreateBank(bank);
        }
    }
}

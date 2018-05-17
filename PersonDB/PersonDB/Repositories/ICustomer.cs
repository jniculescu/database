using System;
using System.Collections.Generic;
using System.Text;
using PersonDB.Models;

namespace PersonDB.Repositories
{
    interface ICustomer
    {
        List<Customer> GetCustomerAccounts();
    }
}

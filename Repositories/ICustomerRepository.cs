using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void CreateNewCustomer(Customer customer);
        Customer GetCustomerById(int id);
    }
}

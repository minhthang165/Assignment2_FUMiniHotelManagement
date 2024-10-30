using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void CreateNewCustomer(Customer customer) => CustomerDAO.CreateNewCustomer(customer);
        public void DeleteCustomer(Customer customer) => CustomerDAO.DeleteCustomer(customer);

        public Customer GetCustomerById(int id) => CustomerDAO.GetCustomerById(id);

        public List<Customer> GetCustomers() => CustomerDAO.GetCustomers();

        public void UpdateCustomer(Customer customer) => CustomerDAO.UpdateCustomer(customer);
    }
}

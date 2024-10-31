using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using var context = new FuminiHotelManagementContext();
                customers = context.Customers
                 .Include(c => c.BookingReservations) 
                 .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }

        public static void CreateNewCustomer(Customer customer)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateCustomer(Customer customer)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                var customerToUpdate = GetCustomerById(customer.CustomerId);

                if (customerToUpdate != null)
                {
                    context.Customers.Update(customer);
                    context.SaveChanges(); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCustomer(Customer customer)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                var customerToRemove = GetCustomerById(customer.CustomerId);

                if (customerToRemove != null)
                {
                    context.Customers.Remove(customerToRemove);
                    context.SaveChanges(); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Customer GetCustomerById(int id)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                return context.Customers.FirstOrDefault(c => c.CustomerId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Customer GetCustomerToLogin(string customerEmail, string password)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true).Build();

            try
            {
                if (customerEmail == configuration["AdminAccount:Email"] && password == configuration["AdminAccount:Password"])
                {
                    return new Customer
                    {
                        CustomerFullName = "Admin",
                        EmailAddress = customerEmail,
                        CustomerId = -1
                    };
                } else
                {
                    using var context = new FuminiHotelManagementContext();
                    return context.Customers.FirstOrDefault(c => (c.EmailAddress == customerEmail && c.Password == password));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

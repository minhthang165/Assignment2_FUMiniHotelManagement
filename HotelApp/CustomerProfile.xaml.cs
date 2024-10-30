using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelApp
{
    /// <summary>
    /// Interaction logic for CustomerProfile.xaml
    /// </summary>
    public partial class CustomerProfile : Window
    {
        private readonly ICustomerRepository customerRepository;
        private int CustomerId;
        public CustomerProfile(int id)
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
            CustomerId = id;
            LoadCustomerProfile();
        }

        public void LoadCustomerProfile()
        {
            try
            {
                var customer = customerRepository.GetCustomerById(CustomerId);
                txtCusName.Text = customer.CustomerFullName;
                txtBirthday.Text = customer.CustomerBirthday.Value.ToString("yyyy-MM-dd");
                txtEmail.Text = customer.EmailAddress;
                txtTelephone.Text = customer.Telephone.ToString();
                txtStatus.Text = customer.CustomerStatus.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error when show customer profile");
            }
        }
    }
}

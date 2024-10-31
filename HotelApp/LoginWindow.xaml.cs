using BusinessObjects.Models;
using Repositories;
using System.Windows;

namespace HotelApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ICustomerRepository customerRepository;
        public LoginWindow()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = customerRepository.GetCustomerToLogin(txtUser.Text, txtPass.Password);
            if (customer != null)
            {
                switch (customer.CustomerFullName)
                {
                    case "Admin":
                        this.Hide();
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        break;
                    default:
                        this.Hide();
                        CustomerWindow customerWindow = new CustomerWindow(customer.CustomerId);
                        customerWindow.Show();
                        break;
                } 
            }
            else
            {
                MessageBox.Show("You are not permission");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

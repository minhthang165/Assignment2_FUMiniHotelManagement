using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly ICustomerRepository customerRepository;
        public AdminWindow()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
            LoadCustomerList();
        }

        public void LoadCustomerList()
        {
            try
            {
                var customer = customerRepository.GetCustomers();
                if (customer == null)
                {
                    MessageBox.Show("There is no customer yet");
                } else
                {
                    dgData.ItemsSource = customer;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error when show customer profile");
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer = new Customer();
                customer.CustomerFullName = txtFullName.Text;
                customer.CustomerBirthday = DateOnly.Parse(txtBirthday.Text);
                customer.Telephone = txtTelephone.Text;
                customer.EmailAddress = txtEmail.Text;
                customer.CustomerStatus = Byte.Parse(txtStatus.Text);
                customer.Password = txtPassword.Text;
                customerRepository.CreateNewCustomer(customer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error when creating new customer");
            }
            finally
            {
                LoadCustomerList();
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtFullName.Text.Length > 0)
                {
                    Customer customer = new Customer();
                    customer.CustomerId = Int32.Parse(txtID.Text);
                    customer.CustomerFullName = txtFullName.Text;
                    customer.CustomerBirthday = DateOnly.Parse(txtBirthday.Text);
                    customer.Telephone = txtTelephone.Text;
                    customer.EmailAddress = txtEmail.Text;
                    customer.CustomerStatus = Byte.Parse(txtStatus.Text);
                    customer.Password = txtPassword.Text;
                    customerRepository.UpdateCustomer(customer);
                }
                else
                {
                    MessageBox.Show("You must select a customer");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error when updating customer");
            } finally
            {
                LoadCustomerList();
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtFullName.Text.Length > 0)
                {
                    Customer customer = new Customer();
                    customer.CustomerId = Int32.Parse(txtID.Text);
                    customer.CustomerFullName = txtFullName.Text;
                    customer.CustomerBirthday = DateOnly.Parse(txtBirthday.Text);
                    customer.Telephone = txtTelephone.Text;
                    customer.EmailAddress = txtEmail.Text;
                    customer.CustomerStatus = Byte.Parse(txtStatus.Text);
                    customer.Password = txtPassword.Text;
                    customerRepository.DeleteCustomer(customer);
                }
                else
                {
                    MessageBox.Show("You must select a customer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error when deleting customer");
            }
            finally
            {
                LoadCustomerList();
            }
        }

        private void btnRoom_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedIndex == -1) return;
            DataGrid dataGrid = sender as DataGrid;

            if (dataGrid.SelectedIndex < 0) return;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            if (row == null) return;

            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row)?.Parent as DataGridCell;
            if (RowColumn == null) return;

            string id = ((TextBlock)RowColumn.Content)?.Text;

            if (id == null) return;
            Customer customer = customerRepository.GetCustomerById(Int32.Parse(id));
            txtID.Text = customer.CustomerId.ToString();
            txtFullName.Text = customer.CustomerFullName;
            txtTelephone.Text = customer.Telephone;
            txtBirthday.Text = customer.CustomerBirthday.ToString();
            txtEmail.Text = customer.EmailAddress;
            txtStatus.Text = customer.CustomerStatus.ToString();
            txtPassword.Text = customer.Password;
        }
    }
}

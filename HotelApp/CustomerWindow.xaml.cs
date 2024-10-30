using BusinessObjects.Models;
using DataAccessLayer;
using Repositories;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly IBookingRepository bookingRepository;
        private readonly int CustomerId;
        public CustomerWindow(int id)
        {
            InitializeComponent();
            bookingRepository = new BookingRepository();
            CustomerId = id;
            LoadBookingReservationList();
        }

        public void LoadBookingReservationList()
        {
            try
            {
                var BookingList = bookingRepository.GetBookingsListById(CustomerId);
                if (BookingList.Count == 0)
                {
                    MessageBox.Show("No booking list");
                }
                else
                {
                    dgData.ItemsSource = BookingList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on loading booking list");
            }
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CustomerProfile customerProfile = new CustomerProfile(CustomerId);
            customerProfile.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
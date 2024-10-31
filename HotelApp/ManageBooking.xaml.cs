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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelApp
{
    /// <summary>
    /// Interaction logic for ManageBooking.xaml
    /// </summary>
    public partial class ManageBooking : Window
    {
        private readonly IBookingRepository bookingRepository;
        public ManageBooking()
        {
            InitializeComponent();
            bookingRepository = new BookingRepository();
            LoadBookingReservationList();
        }

        public void LoadBookingReservationList()
        {
            try
            {
                var BookingList = bookingRepository.GetBookingList();
                if (BookingList.Count == 0)
                {
                    MessageBox.Show("No booking list");
                }
                else
                {
                    foreach (var Booking in BookingList)
                    {
                        Debug.WriteLine(Booking.BookingReservationId);
                        foreach (var BookingDetails in Booking.BookingDetails)
                        {
                            Debug.WriteLine(BookingDetails.ActualPrice);
                        }
                    }
                    dgData.ItemsSource = BookingList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on loading booking list");
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnViewCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
        }

        private void btnViewBooking_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ManageRoom manageRoom = new ManageRoom();
            manageRoom.Show();
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

            BookingReservation booking = bookingRepository.GetBookingByBookingId(Int32.Parse(id));
            if (booking == null) return;
            txtBookingReverID.Text = booking.BookingReservationId.ToString();
            txtBookingDate.Text = booking.BookingDate.ToString();
            txtTotalPrice.Text = booking.TotalPrice.ToString();
            txtBookingStatus.Text = booking.BookingStatus.ToString();
            txtCustomer.Text = booking.CustomerId.ToString();
        }
    }


}

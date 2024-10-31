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
    /// Interaction logic for ManageRoom.xaml
    /// </summary>
    public partial class ManageRoom : Window
    {
        private readonly IRoomRepository roomRepository;
        public ManageRoom()
        {
            InitializeComponent();
            roomRepository = new RoomRepository();
            LoadRoomList();
        }

        public void LoadRoomList()
        {
            try
            {
                var rooms = roomRepository.GetRooms();
                if (rooms == null)
                {
                    MessageBox.Show("There are no room yet");
                }
                else
                {
                    dgData.ItemsSource = rooms;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error when loading room list");
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomInformation roomInformation = new RoomInformation();
                roomInformation.RoomNumber = txtRoomNum.Text;
                roomInformation.RoomDetailDescription = txtRoomDetail.Text;
                roomInformation.RoomMaxCapacity = Int32.Parse(txtCapacity.Text);
                roomInformation.RoomTypeId = Int32.Parse(txtTypeId.Text);
                roomInformation.RoomStatus = Byte.Parse(txtStatus.Text);
                roomInformation.RoomPricePerDay = Decimal.Parse(txtPricePerDay.Text);
                roomRepository.CreateNewRoom(roomInformation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error when creating new customer");
            }
            finally
            {
                LoadRoomList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtRoomNum.Text.Length > 0)
                {
                    RoomInformation roomInformation = new RoomInformation();
                    roomInformation.RoomNumber = txtRoomNum.Text;
                    roomInformation.RoomDetailDescription = txtRoomDetail.Text;
                    roomInformation.RoomMaxCapacity = Int32.Parse(txtCapacity.Text);
                    roomInformation.RoomTypeId = Int32.Parse(txtTypeId.Text);
                    roomInformation.RoomStatus = Byte.Parse(txtStatus.Text);
                    roomInformation.RoomPricePerDay = Decimal.Parse(txtPricePerDay.Text);
                    roomRepository.UpdateRoom(roomInformation);
                }
                else
                {
                    MessageBox.Show("You must select a room");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error when updating room");
            }
            finally
            {
                LoadRoomList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtRoomNum.Text.Length > 0)
                {
                    RoomInformation roomInformation = new RoomInformation();
                    roomInformation.RoomNumber = txtRoomNum.Text;
                    roomInformation.RoomDetailDescription = txtRoomDetail.Text;
                    roomInformation.RoomMaxCapacity = Int32.Parse(txtCapacity.Text);
                    roomInformation.RoomTypeId = Int32.Parse(txtTypeId.Text);
                    roomInformation.RoomStatus = Byte.Parse(txtStatus.Text);
                    roomInformation.RoomPricePerDay = Decimal.Parse(txtPricePerDay.Text);
                    roomRepository.DeleteRoom(roomInformation);
                }
                else
                {
                    MessageBox.Show("You must select a room");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error when deleting room");
            }
            finally
            {
                LoadRoomList();
            }
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
            ManageBooking manageBooking = new ManageBooking();
            manageBooking.Show();
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
            Debug.WriteLine(id);

            if (id == null) return;
            RoomInformation roomInformation = roomRepository.GetRoomById(Int32.Parse(id));
            txtRoomId.Text = roomInformation.RoomId.ToString();
            txtRoomNum.Text = roomInformation.RoomNumber.ToString();
            txtRoomDetail.Text = roomInformation.RoomDetailDescription;
            txtCapacity.Text = roomInformation.RoomMaxCapacity.ToString();
            txtTypeId.Text = roomInformation.RoomTypeId.ToString();
            txtStatus.Text = roomInformation.RoomStatus.ToString();
            txtPricePerDay.Text = roomInformation.RoomPricePerDay.ToString();
        }
    }
}

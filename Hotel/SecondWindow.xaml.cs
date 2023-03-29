using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using Hotel.HotelDbDataSet1TableAdapters;

namespace Hotel
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        hotel_roomsTableAdapter rooms = new hotel_roomsTableAdapter();
        bookingsTableAdapter bookings = new bookingsTableAdapter();
       
        public SecondWindow()
        {
            InitializeComponent();
            HotelRoomsDataGrid.ItemsSource = rooms.GetData();
            BookingsDataGrid.ItemsSource = bookings.GetData(); 
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (BookingsDataGrid.SelectedItem != null)
            {
               
                DataRowView rowView = (DataRowView)BookingsDataGrid.SelectedItem;
                string rowData = string.Join(",", rowView.Row.ItemArray);

               
                string fileName = "data.txt";
                string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

                
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine(rowData);
                }

                MessageBox.Show("Данные успешно сохранены");
            }
            else
            {
                MessageBox.Show("Выберите строку для сохранения данных");
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

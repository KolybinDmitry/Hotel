using System;
using System.Collections.Generic;
using System.Data;
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
using Hotel.HotelDbDataSet1TableAdapters;
using static System.Net.Mime.MediaTypeNames;

namespace Hotel
{
    /// <summary>
    /// Логика взаимодействия для FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        logindataTableAdapter allusers = new logindataTableAdapter();
        EmployeeTableAdapter employee = new EmployeeTableAdapter();
        roleTableAdapter role = new roleTableAdapter();
        DepartmentTableAdapter department = new DepartmentTableAdapter();
        job_titleTableAdapter job_Title = new job_titleTableAdapter();
        ReservationTableAdapter resertvation = new ReservationTableAdapter();
        RoomTableAdapter room = new RoomTableAdapter();
        CustomerTableAdapter customer = new CustomerTableAdapter();
        public FirstWindow()
        {
            InitializeComponent();
            EmployeeDataGrid.ItemsSource = employee.GetData();
            AllUsers.ItemsSource = allusers.GetData();
            ReservationDataGrid.ItemsSource= resertvation.GetData();
            RoleDataGrid.ItemsSource = role.GetData();
            RoomIdCbx.ItemsSource = room.GetData();
            RoomIdCbx.DisplayMemberPath = "room_number";
            RoomIdCbx.SelectedValuePath = "room_id";
            RoleCb.ItemsSource = role.GetData();
            RoleCb.DisplayMemberPath = "name";
            RoleCb.SelectedValuePath = "id";
            CustomerIdCbx.ItemsSource = customer.GetData();
            CustomerIdCbx.DisplayMemberPath = "first_name";
            CustomerIdCbx.SelectedValuePath = "customer_id";
            JobTitleIdCb.ItemsSource = job_Title.GetData();
            JobTitleIdCb.DisplayMemberPath = "job_title";
            JobTitleIdCb.SelectedValuePath = "job_id";
            DepartmentIdCb.ItemsSource = department.GetData();
            DepartmentIdCb.DisplayMemberPath = "department_name";
            DepartmentIdCb.SelectedValuePath = "department_id";
        }


        private void AllUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllUsers.SelectedItem as DataRowView != null)
            {
                IdTbxUsers.Text = Convert.ToString((AllUsers.SelectedItem as DataRowView).Row[0]);
                LoginTbx.Text = Convert.ToString((AllUsers.SelectedItem as DataRowView).Row[1]);
                PasswordTbx.Text = Convert.ToString((AllUsers.SelectedItem as DataRowView).Row[2]);

            }
        }

        private void RoleAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(IdTbxUsers.Text, out int idUsers))
            {
                MessageBox.Show("Ошибка! Введите целочисленное значение в поле 'ID '.");
                return;
            }
            object id = (RoleCb.SelectedItem as DataRowView).Row[0];
            allusers.InsertRole(Convert.ToInt32(IdTbxUsers.Text), LoginTbx.Text, PasswordTbx.Text, Convert.ToInt32(id));
            AllUsers.ItemsSource = allusers.GetData();
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(IdTbxUsers.Text, out int idUsers))
            {
                MessageBox.Show("Ошибка! Введите целочисленное значение в поле 'ID '.");
                return;
            }
            object id = (RoleCb.SelectedItem as DataRowView).Row[0];
            object id1 = (AllUsers.SelectedItem as DataRowView).Row[0];
            allusers.UpdateUser(Convert.ToInt32(IdTbxUsers.Text), LoginTbx.Text, PasswordTbx.Text, Convert.ToInt32(id), Convert.ToInt32(id1));
            AllUsers.ItemsSource = allusers.GetData();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            object id = (AllUsers.SelectedItem as DataRowView).Row[0];
            allusers.DeleteUser(Convert.ToInt32((int)id));
            AllUsers.ItemsSource = allusers.GetData();

        }

        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem as DataRowView != null)
            {
                EmployeeIdTbx.Text = Convert.ToString((EmployeeDataGrid.SelectedItem as DataRowView).Row[0]);
                EmployeeFirstName.Text = Convert.ToString((EmployeeDataGrid.SelectedItem as DataRowView).Row[1]);
                EmployeeLastName.Text = Convert.ToString((EmployeeDataGrid.SelectedItem as DataRowView).Row[2]);
                AddressTextBox.Text = Convert.ToString((EmployeeDataGrid.SelectedItem as DataRowView).Row[3]);
                PhoneTextBox.Text = Convert.ToString((EmployeeDataGrid.SelectedItem as DataRowView).Row[4]);
                EmailTextBox.Text = Convert.ToString((EmployeeDataGrid.SelectedItem as DataRowView).Row[5]);
                HireDateTbx.Text = Convert.ToString((EmployeeDataGrid.SelectedItem as DataRowView).Row[7]);
                SalaryTextBox.Text = Convert.ToString((EmployeeDataGrid.SelectedItem as DataRowView).Row[8]);
            }
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(EmployeeIdTbx.Text, out int idUsers))
            {
                MessageBox.Show("Ошибка! Введите целочисленное значение в поле 'ID '.");
                return;
            }
            if (!DateTime.TryParse(HireDateTbx.Text, out DateTime hireDate))
            {
                MessageBox.Show("Ошибка! Введите дату в формате 'dd.mm.yyyy' в поле 'Дата принятия'.");
                return;
            }
            if (!int.TryParse(PhoneTextBox.Text, out int phone))
            {
                MessageBox.Show("Ошибка! Введите целочисленное значение в поле 'Телефон '.");
                return;
            }
            if (!Decimal.TryParse(SalaryTextBox.Text, out decimal salary))
            {
                MessageBox.Show("Ошибка! Введите целочисленное значение в поле 'Зарплата '.");
                return;
            }
            if (int.TryParse(EmployeeFirstName.Text, out int firstName))
            {
                MessageBox.Show("Ошибка! Введите строковое  значение в поле 'Имя '.");
                return;
            }
            if (int.TryParse(EmployeeLastName.Text, out int secondtName))
            {
                MessageBox.Show("Ошибка! Введите строковое значение в поле 'Фамилия '.");
                return;
            }
            if (int.TryParse(AddressTextBox.Text, out int addres))
            {
                MessageBox.Show("Ошибка! Введите строковое значение в поле 'Адрес '.");
                return;
            }
            object id = (JobTitleIdCb.SelectedItem as DataRowView).Row[0];
            object id1 = (DepartmentIdCb.SelectedItem as DataRowView).Row[0];
            employee.InsertEmployee(Convert.ToInt32(EmployeeIdTbx.Text),EmployeeFirstName.Text,EmployeeLastName.Text,AddressTextBox.Text,PhoneTextBox.Text,EmailTextBox.Text,Convert.ToInt32(id),HireDateTbx.Text,Convert.ToDecimal(SalaryTextBox.Text),Convert.ToInt32(id1));
            EmployeeDataGrid.SelectedItem = employee.GetData();
        }

        private void ChancgeDataEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(EmployeeIdTbx.Text, out int idUsers))
            {
                MessageBox.Show("Ошибка! Введите целочисленное значение в поле 'ID '.");
                return;
            }
            if (!DateTime.TryParse(HireDateTbx.Text, out DateTime hireDate))
            {
                MessageBox.Show("Ошибка! Введите дату в формате 'dd.mm.yyyy' в поле 'Дата принятия'.");
                return;
            }
            if (!int.TryParse(PhoneTextBox.Text, out int phoneNumber))
            {
                MessageBox.Show("Ошибка! Введите целочисленное значение в поле 'Телефон '.");
                return;
            }
            if (!Decimal.TryParse(SalaryTextBox.Text, out decimal salary))
            {
                MessageBox.Show("Ошибка! Введите целочисленное значение в поле 'Зарплата '.");
                return;
            }
            if (int.TryParse(EmployeeFirstName.Text, out int firstName ))
            {
                MessageBox.Show("Ошибка! Введите строковое  значение в поле 'Имя '.");
                return;
            }
            if (int.TryParse(EmployeeLastName.Text, out int secondtName))
            {
                MessageBox.Show("Ошибка! Введите строковое значение в поле 'Фамилия '.");
                return;
            }
            if (int.TryParse(AddressTextBox.Text, out int addres))
            {
                MessageBox.Show("Ошибка! Введите строковое значение в поле 'Адрес '.");
                return;
            }
            else
            {


                object id = (JobTitleIdCb.SelectedItem as DataRowView).Row[0];
                object id1 = (DepartmentIdCb.SelectedItem as DataRowView).Row[0];
                object id2 = (EmployeeDataGrid.SelectedItem as DataRowView).Row[0];
                employee.UpdateEmployee(Convert.ToInt32(EmployeeIdTbx.Text), Convert.ToString(EmployeeFirstName.Text), Convert.ToString(EmployeeLastName.Text), Convert.ToString(AddressTextBox.Text), PhoneTextBox.Text, EmailTextBox.Text, Convert.ToInt32(id), HireDateTbx.Text, Convert.ToDecimal(SalaryTextBox.Text), Convert.ToInt32(id1), Convert.ToInt32(id2));
                EmployeeDataGrid.ItemsSource = employee.GetData();
            }
            EmployeeDataGrid.ItemsSource = employee.GetData();
        }

        private void DeleteDataEmployee_Click(object sender, RoutedEventArgs e)
        {
            object id = (EmployeeDataGrid.SelectedItem as DataRowView).Row[0];
            employee.DeleteEmployee(Convert.ToInt32((int)id));
            EmployeeDataGrid.ItemsSource = employee.GetData();

        }

        private void InsertReservButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(IDReservBx.Text, out int idReserv))
            {
                MessageBox.Show("Ошибка! Введите целочисленное значение в поле 'ID брони'.");
                return;
            }
            if (!DateTime.TryParse(ReservDateBx.Text, out DateTime reservDate))
            {
                MessageBox.Show("Ошибка! Введите дату в формате 'dd.mm.yyyy' в поле 'Дата бронирования'.");
                return;
            }
            if (!DateTime.TryParse(CheckInDateBx.Text, out DateTime checkinDate))
            {
                MessageBox.Show("Ошибка! Введите дату в формате 'dd.mm.yyyy' в поле 'Дата бронирования'.");
                return;
            }
            if (!DateTime.TryParse(CheckOutDateBx.Text, out DateTime checkoutDate))
            {
                MessageBox.Show("Ошибка! Введите дату в формате 'dd.mm.yyyy' в поле 'Дата бронирования'.");
                return;
            }
            object id = (RoomIdCbx.SelectedItem as DataRowView).Row[0];
            object id1 = (CustomerIdCbx.SelectedItem as DataRowView).Row[0];
            resertvation.InsertReserv(Convert.ToInt32(IDReservBx.Text), ReservDateBx.Text, CheckInDateBx.Text, CheckOutDateBx.Text, Convert.ToInt32(id), Convert.ToInt32(id1));
            ReservationDataGrid.ItemsSource = resertvation.GetData();
        }

        private void ReservationDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReservationDataGrid.SelectedItem as DataRowView != null)
            {
                IDReservBx.Text = Convert.ToString((ReservationDataGrid.SelectedItem as DataRowView).Row[0]);
                ReservDateBx.Text = Convert.ToString((ReservationDataGrid.SelectedItem as DataRowView).Row[1]);
                CheckInDateBx.Text = Convert.ToString((ReservationDataGrid.SelectedItem as DataRowView).Row[2]);
                CheckOutDateBx.Text = Convert.ToString((ReservationDataGrid.SelectedItem as DataRowView).Row[3]);
                RoomIdCbx.SelectedValue = Convert.ToInt32((ReservationDataGrid.SelectedItem as DataRowView).Row[4]);
                CustomerIdCbx.SelectedValue = Convert.ToUInt32((ReservationDataGrid.SelectedItem as DataRowView).Row[5]);
            }
        }

        private void ChangeReservDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(IDReservBx.Text, out int idReserv))
            {
                MessageBox.Show("Ошибка! Введите целочисленное значение в поле 'ID брони'.");
                return;
            }
            if (!DateTime.TryParse(ReservDateBx.Text, out DateTime reservDate))
            {
                MessageBox.Show("Ошибка! Введите дату в формате 'dd.mm.yyyy' в поле 'Дата бронирования'.");
                return;
            }
            if (!DateTime.TryParse(CheckInDateBx.Text, out DateTime checkinDate))
            {
                MessageBox.Show("Ошибка! Введите дату в формате 'dd.mm.yyyy' в поле 'Дата бронирования'.");
                return;
            }
            if (!DateTime.TryParse(CheckOutDateBx.Text, out DateTime checkoutDate))
            {
                MessageBox.Show("Ошибка! Введите дату в формате 'dd.mm.yyyy' в поле 'Дата бронирования'.");
                return;
            }
            object id = (RoomIdCbx.SelectedItem as DataRowView).Row[0];
            object id1 = (CustomerIdCbx.SelectedItem as DataRowView).Row[0];
            object id2 = (ReservationDataGrid.SelectedItem as DataRowView).Row[0];
            resertvation.UpdateReserv(Convert.ToInt32(IDReservBx.Text), ReservDateBx.Text, CheckInDateBx.Text, CheckOutDateBx.Text, Convert.ToInt32(id), Convert.ToInt32(id1),Convert.ToInt32(id2));
            ReservationDataGrid.ItemsSource = resertvation.GetData();
        }

        private void DeleteDataReservButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (ReservationDataGrid.SelectedItem as DataRowView).Row[0];
            resertvation.DeleteReserv(Convert.ToInt32(id));
            ReservationDataGrid.ItemsSource = resertvation.GetData();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();   
        }

        private void AddRole_Click(object sender, RoutedEventArgs e)
        {
          role.InsertRole(Convert.ToInt32(IdRoleTbx.Text),NameRoleTbx.Text);
            RoleDataGrid.ItemsSource = role.GetData();  
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (RoleDataGrid.SelectedItem as DataRowView).Row[0];
            role.UpdateRole(Convert.ToInt32(IdRoleTbx.Text), NameRoleTbx.Text, Convert.ToInt32(id));
            RoleDataGrid.ItemsSource = role.GetData();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (RoleDataGrid.SelectedItem as DataRowView).Row[0];
            role.DeleteRole(Convert.ToInt32(id));
            RoleDataGrid.ItemsSource = role.GetData();
        }

        private void RoleCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //object cell = (RoleCb.SelectedItem as DataRowView).Row[0];
            //id = Convert.ToInt32(cell);
        }
    }


    }


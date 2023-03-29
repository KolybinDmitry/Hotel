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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hotel.HotelDbDataSetTableAdapters;

namespace Hotel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        logindataTableAdapter adapter = new logindataTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            var allogins = adapter.GetData().Rows;
            bool found = false;

            for (int i = 0;i < allogins.Count; i++)
            {
                if (allogins[i][1].ToString() == LoginBx.Text &&
                    allogins[i][2].ToString() == PasswordBx.Password)
                {
                    found = true;
                    int roleId = (int)allogins[i][3];
                    switch (roleId)
                    {
                        case 1:
                            FirstWindow role = new FirstWindow();
                            role.Show();
                            break;
                        case 2:
                            SecondWindow second = new SecondWindow();
                            second.Show();
                            break;
                    }
                    this.Close();
                }
                
            }
            if (!found)
            {
                MessageBox.Show("Миша все ... давай по новой!");
            }
        }
    }
}

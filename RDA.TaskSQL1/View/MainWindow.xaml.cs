using RDA.TaskSQL1.Model;
using RDA.TaskSQL1.View;
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

namespace RDA.TaskSQL1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserInfoEntities _db = new UserInfoEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(TbLogin.Text) ||
                    string.IsNullOrEmpty(PbPassword.Password) ||
                    string.IsNullOrEmpty(TbEmail.Text))


                {
                    MessageBox.Show($"Не все строки заполнены!");
                }
                else
                {
                    _db.Users.Add(new Users()
                    {
                        login = TbLogin.Text,
                        password = PbPassword.Password,
                        email = TbEmail.Text
                    }); ;
                    _db.SaveChanges();
                    MessageBox.Show($"Успех!");
                    TbLogin.Text = string.Empty;
                    PbPassword.Password = string.Empty;
                    TbEmail.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Error 3");
            }
        }

        private void BtnRun_Click(object sender, RoutedEventArgs e)
        {
            new InfoWindow().Show();
            Close();
        }
    }
}

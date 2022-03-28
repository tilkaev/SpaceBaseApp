using SpaceBaseApp.Core;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SpaceBaseApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            txtChoose.Visibility = Visibility.Visible;
        }

        private void btnLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            txtChoose.Visibility = Visibility.Hidden;
        }

        private void tbLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            txtChoose2.Visibility = Visibility.Visible;
        }

        private void tbLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            txtChoose2.Visibility = Visibility.Hidden;
        }

        private void pbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtChoose3.Visibility = Visibility.Visible;
        }

        private void pbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            txtChoose3.Visibility = Visibility.Hidden;
        }

        //////////////////////////////////////////////////////////////

        private void btnLogin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //кнопка логин
        {
            string login = tbLogin.Text;
            string password = pbPassword.Password;


            if (login is "" & password is "")
            {
                //image_password.ToolTip = "Пустые поля";
                //image_login.ToolTip = "Пустые поля";
                return;
            }
            else
            {
                //image_login.Visibility = Visibility.Collapsed;
                //image_password.Visibility = Visibility.Collapsed;
            }


            string sql = String.Format("select логин from Аккаунты_диспетчер where логин collate Latin1_General_CS_AS like '{0}' and пароль collate Latin1_General_CS_AS like '{1}'", login, password);

            SQL sqls = new SQL();

            try
            {
                sqls.SQLConnect();
                DataTable dt = sqls.Inquiry(sql);
                sqls.Close();

                if (dt.Rows.Count != 0)
                {
                    Show_Win(new Window1(dt.Rows[0][0].ToString()));
                }
                else
                {
                    image_login.Visibility = Visibility.Visible;
                    image_login.ToolTip = "Неверный ввод";
                    image_password.Visibility = Visibility.Visible;
                    image_password.ToolTip = "Неверный ввод";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!", "Ошибка!");
                throw;
            }

            var win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void grdHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.Close();
            }
        }
    }
}

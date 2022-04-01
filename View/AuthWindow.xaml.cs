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
using System.Windows.Media.Animation;
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
            FrameManager.TypewriteTextblock(txtIpconfig.Text, txtIpconfig, TimeSpan.FromSeconds(10));
            tbLogin.Text = "ybor";
            pbPassword.Password = "ybor";
            FrameManager.AnimationWindow(this, true);

        }


        #region EVENTERS
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
        #endregion




        public void Show_Win(Window win, double x = 0, double y = 0) // Создание окна закрытие старого
        {
            //win.Owner = this;
            //win.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.Visibility = Visibility.Collapsed;

            win.Closed += (sender2, e2) =>
            {
                tbLogin.Text = "";
                pbPassword.Password = "";
                this.Visibility = Visibility.Visible;
            };
            win.ShowDialog();
        }

        private async void btnLogin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //кнопка логин
        {

            string login = tbLogin.Text;
            string password = pbPassword.Password;


            if (login is "" & password is "")
            {
                FrameManager.TypewriteTextblock("Empty fields", txtError, TimeSpan.FromSeconds(0.5));
                return;
            }


            string sql = String.Format("select Логин from Сотрудники " +
                                        "where Логин collate Latin1_General_CS_AS like '{0}' " +
                                       "and Пароль collate Latin1_General_CS_AS like '{1}'", login, password);

            SQL sqls = new SQL();

            
            try
            {
                sqls.SQLConnect();
                DataTable dt = sqls.Inquiry(sql);
                sqls.Close();

                if (dt.Rows.Count != 0)
                {
                    
                    var win = new MainWindow();
                    win.Opacity = 0;
                    FrameManager.AnimationWindow(this, false);

                    await Task.Delay(TimeSpan.FromSeconds(0.5));
                    this.Visibility = Visibility.Collapsed;

                    win.Show(); 
                    FrameManager.AnimationWindow(win, true);

                    win.Closed += (sender2, e2) =>
                    {
                        tbLogin.Text = "";
                        pbPassword.Password = "";
                        this.Opacity = 0;
                        this.Visibility = Visibility.Visible;
                        FrameManager.AnimationWindow(this, true);
                    };
                }
                else
                {
                    FrameManager.TypewriteTextblock("Invalid login or password", txtError, TimeSpan.FromSeconds(0.5));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!", "Ошибка!");
                throw;
            }
        }


        #region WINDOW TITLE
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
        #endregion

    }
}

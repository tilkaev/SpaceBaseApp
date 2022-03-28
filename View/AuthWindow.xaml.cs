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
            txtIpconfig.Text += "не правильный пароль";
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

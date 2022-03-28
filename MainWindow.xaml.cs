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

namespace SpaceBaseApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStationStatus_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnStationStatus.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnStationStatus_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnStationStatus.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnGuests_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnGuests.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnGuests_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnGuests.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnWorkers_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnWorkers.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnWorkers_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnWorkers.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnApartments_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnApartments.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnApartments_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnApartments.Background = (Brush)converter.ConvertFrom("#005738");
        }

        /////////////////////////////////////////////

        private void grdHeader_MouseDown(object sender, MouseButtonEventArgs e) // перетаскивание окна
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnClose_MouseDown(object sender, MouseButtonEventArgs e) // кнопка закрытия окна
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.Close();
            }
        }

        private void btnMinimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnStationStatus_MouseDown(object sender, MouseButtonEventArgs e) // кнопка Station Status
        {
            mainFrame.Navigate(new StationStatusPage());
        }

        private void btnGuests_MouseDown(object sender, MouseButtonEventArgs e) // кнопка Guests
        {
            mainFrame.Navigate(new GuestsPage());
        }

        private void btnWorkers_MouseDown(object sender, MouseButtonEventArgs e) // кнопка Workers
        {
            mainFrame.Navigate(new WorkersPage());
        }

        private void btnApartments_MouseDown(object sender, MouseButtonEventArgs e) // кнопка Apartments
        {
            mainFrame.Navigate(new ApartmentsPage());
        }     
    }
}

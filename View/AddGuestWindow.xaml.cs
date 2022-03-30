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
using System.Windows.Shapes;

namespace SpaceBaseApp.View
{
    /// <summary>
    /// Логика взаимодействия для AddGuestWindow.xaml
    /// </summary>
    public partial class AddGuestWindow : Window
    {
        public AddGuestWindow()
        {
            InitializeComponent();
        }

        #region Style
        private void btnCancel_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCancel.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnCancel_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCancel.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnAddGuest_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnAddGuest.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnAddGuest_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnAddGuest.Background = (Brush)converter.ConvertFrom("#005738");
        }
        #endregion

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

        private void btnBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnCancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnAddGuest_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

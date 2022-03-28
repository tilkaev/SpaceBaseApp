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

namespace SpaceBaseApp
{
    /// <summary>
    /// Логика взаимодействия для SystemScanWindow.xaml
    /// </summary>
    public partial class SystemScanWindow : Window
    {
        public SystemScanWindow()
        {
            InitializeComponent();
            FrameManager.TypewriteTextblock(txtSysCheck.Text, txtSysCheck, TimeSpan.FromSeconds(10));
        }

        private void btnBack_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnBack.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnBack_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnBack.Background = (Brush)converter.ConvertFrom("#005738");
        }

        ////////////////////////////////////////

        private void btnBack_MouseDown(object sender, MouseButtonEventArgs e) // кнопка Back
        {
            this.Close();
        }

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
    }
}

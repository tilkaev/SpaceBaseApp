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
    /// Логика взаимодействия для StationStatusPage.xaml
    /// </summary>
    public partial class StationStatusPage : Page
    {

        public StationStatusPage()
        {
            InitializeComponent();
        }


        #region EVENTS
        private void btnMainDeck_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnMainDeck.Background = (Brush)converter.ConvertFrom("#003120"); 
        }

        private void btnMainDeck_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnMainDeck.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnLowerDeck_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnLowerDeck.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnLowerDeck_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnLowerDeck.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnSystemScan_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnSystemScan.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnSystemScan_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnSystemScan.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnCam1_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam1.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnCam1_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam1.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnCam2_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam2.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnCam2_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam2.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnCam3_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam3.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnCam3_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam3.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnCam4_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam4.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnCam4_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam4.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnCam5_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam5.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnCam5_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam5.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnCam6_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam6.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnCam6_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam6.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnCam7_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam7.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnCam7_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam7.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnCam8_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam8.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnCam8_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam8.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnCam9_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam9.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnCam9_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam9.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnCam10_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam10.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnCam10_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnCam10.Background = (Brush)converter.ConvertFrom("#005738");
        }
        #endregion

        private void btnMainDeck_MouseDown(object sender, MouseButtonEventArgs e) // кнопка MainDeck
        {
            if (brdMap.Visibility == Visibility.Hidden)
            {
                brdMap.Visibility = Visibility.Visible;
            }
            else
                brdMap.Visibility = Visibility.Hidden;
        }

        private void btnLowerDeck_MouseDown(object sender, MouseButtonEventArgs e)// кнопка LowerDeck
        {
            brdMap.Visibility = Visibility.Hidden;
        }

        private void btnSystemScan_MouseDown(object sender, MouseButtonEventArgs e)// кнопка SystemScan
        {
            var win = new SystemScanWindow();
            win.Show();
        }


        /*                  НА УДАЛЕНИЕ
        private void btnCam1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var win = new CameraView();
            win.Show();
            FrameManager.CamFrame.Navigate(new Cam1Page());
        }

        private void btnCam2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var win = new CameraView();
            win.Show();
            FrameManager.CamFrame.Navigate(new Cam2Page());
        }*/


        private void btnCam_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int index = int.Parse(((Border)sender).Tag.ToString());

            var win = new CameraView(index);
            win.ShowDialog();
        }
        

    }
}

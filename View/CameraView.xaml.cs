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
    public partial class CameraView : Window
    {

        
        string[] CAMERANAMES = {
            "Cam 1 Conference room",
            "Cam 2 Rest room",
            "Cam 3 room",
            "Cam 4 room",
            "Cam 5 room",
            "Cam 6 room",
            "Cam 7 room",
            "Cam 8 room",
            "Cam 9 room",
            "Cam 10 room"
        };

        string[] CAMERIMAGES = {
            "/Images/Cam1.png",
            "/Images/Cam2.jpg",
            "/Images/Cam3.png",
            "/Images/Cam4.png",
            "/Images/Cam5.png",
            "/Images/Cam6.png",
            "/Images/Cam7.png",
            "/Images/Cam8.png",
            "/Images/Cam9.png",
            "/Images/Cam10.png"
        };


        int indexCamera;

        public CameraView(int indexCamera=0)
        {
            this.indexCamera = indexCamera;
            InitializeComponent();
            nameCamera.Text = CAMERANAMES[indexCamera];



            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(CAMERIMAGES[indexCamera], UriKind.Relative);
            bi3.EndInit();
            imageCamera.Stretch = Stretch.Fill;
            imageCamera.Source = bi3;
        }


        #region EVENTS
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

        private void btnPrevious_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnPrevious.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnPrevious_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnPrevious.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnNext_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnNext.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnNext_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnNext.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void grdHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        #endregion


        public void ChangeIndex(bool up = true)
        {
            int temp = indexCamera;
            if (up)
            {
                temp++;
            }
            else
            {
                temp--;
            }

            if (temp >= 0 && temp < 10)
            {
                indexCamera = temp;
                nameCamera.Text = CAMERANAMES[indexCamera];

                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(CAMERIMAGES[indexCamera], UriKind.Relative);
                bi3.EndInit();
                imageCamera.Stretch = Stretch.Fill;
                imageCamera.Source = bi3;
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

        private void btnPrevious_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangeIndex(false);
        }

        private void btnNext_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangeIndex(true);
        }
    }
}

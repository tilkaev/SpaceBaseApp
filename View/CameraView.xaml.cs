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
    /// Логика взаимодействия для CameraView.xaml
    /// </summary>
    public partial class CameraView : Window
    {
        public CameraView()
        {
            InitializeComponent();
            FrameManager.CamFrame = cameraFrame;
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

        //////////////////////////////////////////////////////

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

        private void btnPrevious_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //FrameManager.CamFrame.GoBack();
        }

        private void btnNext_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameManager.CamFrame.Navigate(new Cam2Page());
        }
    }
}

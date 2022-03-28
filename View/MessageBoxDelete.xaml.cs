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
using System.Windows.Threading;

namespace SpaceBaseApp.View
{
    /// <summary>
    /// Логика взаимодействия для MessageBoxDelete.xaml
    /// </summary>
    public partial class MessageBoxDelete : Window
    {
        public MessageBoxDelete()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += timer_Tick;
            timer.Start();
            TypewriteTextblock(txtText.Text, txtText, TimeSpan.FromMilliseconds(500));
        }

        void timer_Tick(object sender, EventArgs e)
        {
            btnCancel.Visibility = Visibility.Visible;
            btnOK.Visibility = Visibility.Visible;
        }

        private void TypewriteTextblock(string textToAnimate, TextBlock txt, TimeSpan timeSpan)
        {
            Storyboard story = new Storyboard();
            story.FillBehavior = FillBehavior.HoldEnd;
            DiscreteStringKeyFrame discreteStringKeyFrame;
            StringAnimationUsingKeyFrames stringAnimationUsingKeyFrames = new StringAnimationUsingKeyFrames();
            stringAnimationUsingKeyFrames.Duration = new Duration(timeSpan);

            string tmp = string.Empty;
            foreach (char c in textToAnimate)
            {
                discreteStringKeyFrame = new DiscreteStringKeyFrame();
                discreteStringKeyFrame.KeyTime = KeyTime.Paced;
                tmp += c;
                discreteStringKeyFrame.Value = tmp;
                stringAnimationUsingKeyFrames.KeyFrames.Add(discreteStringKeyFrame);
            }
            Storyboard.SetTargetName(stringAnimationUsingKeyFrames, txt.Name);
            Storyboard.SetTargetProperty(stringAnimationUsingKeyFrames, new PropertyPath(TextBlock.TextProperty));
            story.Children.Add(stringAnimationUsingKeyFrames);
            story.Begin(txt);
        }

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

        private void btnOK_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnOK.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnOK_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnOK.Background = (Brush)converter.ConvertFrom("#005738");
        }

        ////////////////////////////////////////////////////////////

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

        private void btnCancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnOK_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

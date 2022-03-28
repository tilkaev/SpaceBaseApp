using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SpaceBaseApp
{
    public class FrameManager
    {
        public static Frame CamFrame { get; set; }

        public static void TypewriteTextblock(string textToAnimate, TextBlock txt, TimeSpan timeSpan)
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


        public static async void AnimationWindow(Window win, bool increasing = true)
        {
            float increment = increasing ? 0.1f : -0.1f;
            float i = increasing ? 0 : 1;
            win.Opacity = 0;

            if (increasing)
            {
                win.Show();
            }

            for (; i < 1; i += increment)
            {
                win.Opacity = i;
                await Task.Delay(TimeSpan.FromMilliseconds(25));
            }

            if (!increasing)
            {
                win.Visibility = Visibility.Collapsed;
                win.Opacity = 0;
            }
            else
            {
                win.Visibility = Visibility.Visible;
                win.Opacity = 1;
            }
        }


        public int numberOfCamera { get; set; }

    }
}

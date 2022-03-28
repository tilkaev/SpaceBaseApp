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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpaceBaseApp
{
    /// <summary>
    /// Логика взаимодействия для ApartmentsPage.xaml
    /// </summary>
    public partial class ApartmentsPage : Page
    {

        public async void temo()
        {
            for (int i = 0; i < 6; i++)
            {
                last_name.Text = $"A{i+1}";
                last_border.Text = i.ToString();
                Border rect = XamlReader.Parse(XamlWriter.Save(rectNormal)) as Border;
                rect.Visibility = Visibility.Visible;
                mainStac1row.Children.Add(rect);

                await Task.Delay(TimeSpan.FromMilliseconds(100));
                //var n = rectC1.Child;
                //n.Visibility = Visibility.Collapsed;

            }

            for (int i = 0; i < 6; i++)
            {
                Border rect;

                if (i!=3)
                {
                    last_name.Text = $"B{i + 1}";
                    last_border.Text = i.ToString();
                    rect = XamlReader.Parse(XamlWriter.Save(rectNormal)) as Border;
                }
                else
                {
                    last_nameNotEmpty.Text = $"B{i + 1}";
                    last_borderNotEmpty.Text = i.ToString();
                    rect = XamlReader.Parse(XamlWriter.Save(rectNotEmpty)) as Border;
                }
                rect.Visibility = Visibility.Visible;
                mainStac2row.Children.Add(rect);


                await Task.Delay(TimeSpan.FromMilliseconds(100));

            }

            
        }

        public ApartmentsPage()
        {
            InitializeComponent();

            temo();
           
        }
    }
}

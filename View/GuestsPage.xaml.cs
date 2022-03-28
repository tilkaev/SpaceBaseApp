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
    /// Логика взаимодействия для GuestsPage.xaml
    /// </summary>
    public partial class GuestsPage : Page
    {
        public GuestsPage()
        {
            InitializeComponent();
        }

        private void btnAdd_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnAdd.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnAdd.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnDelete_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnDelete.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnDelete_MouseLeave(object sender, MouseEventArgs e) // кнопка Delete
        {
            var converter = new BrushConverter();
            btnDelete.Background = (Brush)converter.ConvertFrom("#005738");
        }

        /////////////////////////////////////////////////////////

        private void btnAdd_MouseDown(object sender, MouseButtonEventArgs e) // кнопка Add
        {

        }

        private void btnDelete_MouseDown(object sender, MouseButtonEventArgs e) // кнопка Delete
        {
            var win = new View.MessageBoxDelete();
            win.ShowDialog();
        }
    }
}

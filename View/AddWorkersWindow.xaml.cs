using SpaceBaseApp.Core;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class AddWorkersWindow : Window
    {

        DataTable dataTable;
        SQL sqls = new SQL();
        public AddWorkersWindow()
        {
            InitializeComponent();

            string sql = "select ид_водитель, concat(ид_водитель, ' ', фамилия, ' ', имя, ' ', отчество) from Водители"; // Получаем список всех водителей

            //sqls.SQLConnect(); // Подключение к БД
            //dataTable = sqls.Inquiry(sql); // Выполняем запрос, возвращаем результат в виде DataTable
            //sqls.Close();

            foreach (DataRow item in dataTable.Rows)
            {
                //cmb_driver.Items.Add(item[1].ToString()); // Заполнение КомбоБокса
            }
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

        private void btnAddWorker_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnAddWorker.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnAddWorker_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnAddWorker.Background = (Brush)converter.ConvertFrom("#005738");
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

        private void btnCancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnAddWorker_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

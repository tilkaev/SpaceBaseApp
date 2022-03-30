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
    public partial class AddGuestWindow : Window
    {
        DataTable dataTable;
        SQL sqls = new SQL();
        public AddGuestWindow()
        {
            InitializeComponent();
            string sql = "select Ид_Каюты, concat(Рабочее_название, '-', Название_Каюты) from Каюта"; // Получаем список всех водителей

            sqls.SQLConnect(); // Подключение к БД
            dataTable = sqls.Inquiry(sql); // Выполняем запрос, возвращаем результат в виде DataTable
            sqls.Close();

            foreach (DataRow item in dataTable.Rows)
            {
                cbDeck.Items.Add(item[1].ToString()); // Заполнение КомбоБокса
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
        private void grdHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        #endregion


        private void btnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.Close();
            }
        }

        private void btnBack_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (cbDeck.SelectedIndex is -1)
                return;

            if (tbLastName.Text is "")
                return;

            if (tbPatronymic.Text is "")
                return;

            if (tbFirstName.Text is "")
                return;

            if (tbAge.Text is "")
                return;

            string lastName = tbLastName.Text;
            string patronymic = tbPatronymic.Text;
            string firstName = tbFirstName.Text;
            DateTime dateOfBirthday = DateTime.Parse(tbAge.Text);


            sqls.SQLConnect();
            string sql2 = String.Format("INSERT INTO Аккредитации (ид_водитель, дата_выдачи, дата_окончания) VALUES('{0}', '{1}', '{2}')", id_driver, date1.ToShortDateString(), date2.ToShortDateString());


            if (sqls.Execute(sql2))
            {
                sqls.Close();
                MessageBox.Show("Данные записаны", "Ок!");
                this.Close();
            }
            else
            {
                sqls.Close();
                MessageBox.Show("Ошибка!", "Ошибка!");
            }




            this.Close();
        }

        private void btnCancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

    }
}

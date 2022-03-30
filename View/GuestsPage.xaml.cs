using SpaceBaseApp.Core;
using SpaceBaseApp.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpaceBaseApp
{
    public partial class GuestsPage : Page
    {
        DataTable newDataTable;
        DataTable dataTable;

        SQL sqls;
        public GuestsPage()
        {
            InitializeComponent();
            sqls = new SQL();

            Show_Table();
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
            var win = new AddGuestWindow();
            win.ShowDialog();
        }

        private void Find(string str = "")
        {
            if (str != "")
            {
                str = tbSearch.Text.ToLower();
            }

            int num_column = dataTable.Columns.Count;
            dataTable = newDataTable.Copy();

            if (str != "")
            {
                foreach (DataRow item in dataTable.Rows) // Модуль активного поиска
                {
                    int skip_del = 0;

                    for (int i = 0; i < num_column; i++) // Проход по строкам
                    {
                        bool booling = item[i].ToString().ToLower().Contains(str); //str.IndexOf()
                        if (booling)
                        {
                            skip_del = 1;
                            break;
                        }
                        skip_del++;
                    }
                    if (skip_del == num_column)
                    {
                        item.Delete();
                    }
                }
                dataTable.AcceptChanges();
            }

            mainDataGrid.ItemsSource = dataTable.AsDataView();
        }

        public void Show_Table() // Вывод таблицы по индексу
        {

            string sql = String.Format("select * from Клиенты, Бронирование, Каюта where Клиенты.Ид_Клиента = Бронирование.Ид_Клиента and Каюта.Ид_Каюты = Бронирование.Ид_Каюты");
            sqls.SQLConnect(); // Подключение к БД
            newDataTable = sqls.Inquiry(sql); // Выполняем запрос, возвращаем результат в виде DataTable
            dataTable = newDataTable.Copy();
            sqls.Close();

            mainDataGrid.ItemsSource = newDataTable.AsDataView(); // Преобразуем и выводим таблицу
            Find(tbSearch.Text);
            mainDataGrid.Columns[0].Visibility = Visibility.Collapsed; // Скрываем первый столбец с ID

        }

        private void btnDelete_MouseDown(object sender, MouseButtonEventArgs e) // кнопка Delete
        {

            int row = mainDataGrid.SelectedIndex; // Получение индекса выбранного элемента
            if (row != -1)
            {
                bool? result = new View.UniversalMessageBox("Are you sure to delete entries?", MessageType.Delete, MessageButtons.YesNo).ShowDialog();

                if (result.Value)
                {
                    string id = dataTable.Rows[row][0].ToString();
                    string sql = String.Format("DELETE FROM {0} WHERE {1}='{2}'", "Клиенты", "Ид_Клиента", id);

                    sqls.SQLConnect();

                    if (sqls.Execute(sql))
                    {
                        sqls.Close();
                        new View.UniversalMessageBox("Entry deleted!", MessageType.Info, MessageButtons.Ok).ShowDialog();
                        Show_Table();
                    }
                    else
                    {
                        sqls.Close();
                        MessageBox.Show("Ошибка!", "Ошибка!");
                    }
                }
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Find(tbSearch.Text);
        }
    }
}

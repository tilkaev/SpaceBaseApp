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
    /// <summary>
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {

        DataTable newDataTable;
        DataTable dataTable;
        public WorkersPage()
        {
            InitializeComponent();
            string sql = String.Format("select * from Сотрудники");
            SQL sqls = new SQL();


            try
            {
                sqls.SQLConnect();
                newDataTable = sqls.Inquiry(sql); // Выполняем запрос, возвращаем результат в виде DataTable
                dataTable = newDataTable.Copy();
                sqls.Close();

                mainDataGrid.ItemsSource = dataTable.AsDataView();


            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!", "Ошибка!");
                throw;
            }
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
            bool? Result = new View.UniversalMessageBox("Are you sure want to delete the entry?", MessageType.Delete, MessageButtons.YesNo).ShowDialog();

            //if (Result.Value)
            //{
            //    Application.Current.Shutdown();
            //}
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

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Find(tbSearch.Text);
        }
    }
}

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

        //public async void temo()
        //{
        //    for (int i = 0; i < 6; i++)
        //    {
        //        Border rect;
        //        if (i != 6)
        //        {
        //            last_name.Text = $"A{i + 1}";
        //            last_border.Text = i.ToString();
        //            rect = XamlReader.Parse(XamlWriter.Save(rectNormal)) as Border;
        //        }
        //        else
        //        {
        //            last_name.Text = $"A{i + 1}";
        //            last_border.Text = i.ToString();
        //            rect = XamlReader.Parse(XamlWriter.Save(rectNormal)) as Border;
        //        }
        //        rect.Visibility = Visibility.Visible;
        //        mainStac1row.Children.Add(rect);

        //        await Task.Delay(TimeSpan.FromMilliseconds(100));
        //        //var n = rectC1.Child;
        //        //n.Visibility = Visibility.Collapsed;

        //    }

        //    for (int i = 0; i < 6; i++)
        //    {
        //        Border rect;

        //        if (i != 3)
        //        {
        //            last_name.Text = $"B{i + 1}";
        //            last_border.Text = i.ToString();
        //            rect = XamlReader.Parse(XamlWriter.Save(rectNormal)) as Border;
        //        }
        //        else
        //        {
        //            last_nameNotEmpty.Text = $"B{i + 1}";
        //            last_borderNotEmpty.Text = i.ToString();
        //            rect = XamlReader.Parse(XamlWriter.Save(rectNotEmpty)) as Border;
        //        }
        //        rect.Visibility = Visibility.Visible;
        //        mainStac2row.Children.Add(rect);


        //        await Task.Delay(TimeSpan.FromMilliseconds(100));
        //    }


        //    for (int i = 0; i < 6; i++)
        //    {
        //        Border rect;

        //        if (i != 1)
        //        {
        //            last_name.Text = $"C{i + 1}";
        //            last_border.Text = i.ToString();
        //            rect = XamlReader.Parse(XamlWriter.Save(rectNormal)) as Border;
        //        }
        //        else
        //        {
        //            last_nameNotEmpty.Text = $"C{i + 1}";
        //            last_borderNotEmpty.Text = i.ToString();
        //            rect = XamlReader.Parse(XamlWriter.Save(rectNotEmpty)) as Border;
        //        }
        //        rect.Visibility = Visibility.Visible;
        //        mainStac3row.Children.Add(rect);


        //        await Task.Delay(TimeSpan.FromMilliseconds(100));

        //    }

        //    for (int i = 0; i < 6; i++)
        //    {
        //        Border rect;

        //        if (i != 1)
        //        {
        //            last_name.Text = $"D{i + 1}";
        //            last_border.Text = i.ToString();
        //            rect = XamlReader.Parse(XamlWriter.Save(rectNormal)) as Border;
        //        }
        //        else
        //        {
        //            last_nameNotEmpty.Text = $"D{i + 1}";
        //            last_borderNotEmpty.Text = i.ToString();
        //            rect = XamlReader.Parse(XamlWriter.Save(rectNotEmpty)) as Border;
        //        }
        //        rect.Visibility = Visibility.Visible;
        //        mainStac4row.Children.Add(rect);


        //        await Task.Delay(TimeSpan.FromMilliseconds(100));

        //    }


        //}

        SQL sqls;
        DataTable newDataTable;
        DataTable dataTable;
        public ApartmentsPage()
        {
            InitializeComponent();

            sqls = new SQL();

            Show_Table();


        }

        public void Show_Table() // Вывод таблицы по индексу
        {

            string sql = String.Format("select * from Каюта where(Ид_Каюты <= 13)");
            sqls.SQLConnect(); // Подключение к БД
            newDataTable = sqls.Inquiry(sql); // Выполняем запрос, возвращаем результат в виде DataTable
            dataTable = newDataTable.Copy();
            sqls.Close();
            lViewAparts.ItemsSource = newDataTable.AsDataView(); // Преобразуем и выводим таблицу

            string sql2 = String.Format("select * from Каюта where(Ид_Каюты > 13)");
            sqls.SQLConnect(); // Подключение к БД
            newDataTable = sqls.Inquiry(sql2); // Выполняем запрос, возвращаем результат в виде DataTable
            dataTable = newDataTable.Copy();
            sqls.Close();
            lViewAparts2.ItemsSource = newDataTable.AsDataView(); // Преобразуем и выводим таблицу
            //Find(tbSearch.Text);
            //mainDataGrid.Columns[0].Visibility = Visibility.Collapsed; // Скрываем первый столбец с ID

            

            //now fetching the value 
            

        }



        private void btndil_Click(object sender, RoutedEventArgs e)
        {

            string sql2 = String.Format($"select * from Каюта where Ид_Каюты = {((Button)sender).Tag}");
            sqls.SQLConnect(); // Подключение к БД
            newDataTable = sqls.Inquiry(sql2); // Выполняем запрос, возвращаем результат в виде DataTable
            dataTable = newDataTable.Copy();
            sqls.Close();




            FrameManager.TypewriteTextblock($"Number: {dataTable.Rows[0][1]}", txtNumberKayuta, TimeSpan.FromMilliseconds(300));
            FrameManager.TypewriteTextblock($"Name: {dataTable.Rows[0][2]}", txtNameKayuta, TimeSpan.FromMilliseconds(300));
            FrameManager.TypewriteTextblock($"Status: Free", txtStatus, TimeSpan.FromMilliseconds(300));
            FrameManager.TypewriteTextblock($"Count: {dataTable.Rows[0][3]}", txtMaxCount, TimeSpan.FromMilliseconds(300));
            FrameManager.TypewriteTextblock($"Class: {dataTable.Rows[0][4]}", txtClass, TimeSpan.FromMilliseconds(300));
            FrameManager.TypewriteTextblock($"Cost: {dataTable.Rows[0][5]}", txtCost, TimeSpan.FromMilliseconds(300));

        }

        private void lViewAparts2_Selected(object sender, RoutedEventArgs e)
        {

            var selItem = lViewAparts2.SelectedItems as DataRowView;

            var id = selItem["Ид_Каюты"];

            MessageBox.Show(id.ToString());
        }

        private void ListView_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}

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

namespace SpaceBaseApp.View
{
    /// <summary>
    /// Логика взаимодействия для UniversalMessageBox.xaml
    /// </summary>
    public partial class UniversalMessageBox : Window
    {
        public UniversalMessageBox(string Message, MessageType Type, MessageButtons Buttons)
        {
            InitializeComponent();

            txtText.Text = Message;
            switch (Type)
            {

                case MessageType.Info:
                    txtTitle.Text = "Info";
                    break;
                case MessageType.Confirmation:
                    txtTitle.Text = "Confirmation";
                    break;
                case MessageType.Success:
                    txtTitle.Text = "Success";
                    break;
                case MessageType.Warning:
                    txtTitle.Text = "Warning";
                    break;
                case MessageType.Error:
                    txtTitle.Text = "Error";
                    break;
                case MessageType.Delete:
                    txtTitle.Text = "Deleting data";
                    break;
            }
            switch (Buttons)
            {
                case MessageButtons.OkCancel:
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.YesNo:
                    btnOK.Visibility = Visibility.Collapsed; btnCancel.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.Ok:
                    btnOK.Visibility = Visibility.Visible;
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
            }

            FrameManager.TypewriteTextblock(txtText.Text, txtText, TimeSpan.FromMilliseconds(500));
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

        private void btnNo_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnNo.Background = (Brush)converter.ConvertFrom("#005738");
        }

        private void btnNo_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnNo.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnYes_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnYes.Background = (Brush)converter.ConvertFrom("#003120");
        }

        private void btnYes_MouseLeave(object sender, MouseEventArgs e)
        {
            var converter = new BrushConverter();
            btnYes.Background = (Brush)converter.ConvertFrom("#005738");
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

        private void btnYes_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnNo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnCancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOK_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }

    public enum MessageType
    {
        Info,
        Confirmation,
        Success,
        Warning,
        Error,
        Delete,
    }
    public enum MessageButtons
    {
        OkCancel,
        YesNo,
        Ok,
    }
}

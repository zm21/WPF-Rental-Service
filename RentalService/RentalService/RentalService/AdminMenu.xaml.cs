using RentalService.Users;
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
using System.Windows.Threading;

namespace RentalService
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        private UserControl ActiveControl;
        private Admin admin;
        DispatcherTimer timer;
        public AdminMenu(Admin admin)
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
            Timer_Tick(this, EventArgs.Empty);
            HideSubMenu();
            this.admin = admin;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime cur_date = DateTime.Now;
            lb_time.Content = cur_date.ToLongTimeString();
            lb_date.Content = cur_date.ToLongDateString();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void BtnCloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnMaximizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void BtnMinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void HideSubMenu()
        {
            if (SubRentMenu.Visibility == Visibility.Visible)
                SubRentMenu.Visibility = Visibility.Collapsed;
        }

        private void ShowSubMenu(StackPanel subMenu)
        {
            if (subMenu.Visibility == Visibility.Collapsed)
            {
                HideSubMenu();
                subMenu.Visibility = Visibility.Visible;
            }
            else
                subMenu.Visibility = Visibility.Collapsed;
        }
        private void ButtonRent_Click(object sender, RoutedEventArgs e)
        {
            ShowSubMenu(SubRentMenu);

        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void OpenUserControl(UserControl userControl)
        {
            if (userControl is RemoveUser)
            {
                (userControl as RemoveUser).Closing += CloseActiveControl;
                (userControl as RemoveUser).OpenMsg += ShowMsg;
            }
            Desktop.Children.Clear();
            RentalDesktop.Visibility = Visibility.Hidden;
            Desktop.Children.Add(userControl);
            ActiveControl = userControl;
        }
        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if(!(ActiveControl is RemoveUser))
                OpenUserControl(new RemoveUser());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CloseActiveControl();
        }
        private void ShowMsg(string title, string msg)
        {
            MsgBox msgBox = new MsgBox(title, msg);
            msgBox.Owner = this;
            msgBox.ShowDialog();
        }
        private void CloseActiveControl()
        {
            ActiveControl = null;
            Desktop.Children.Clear();
            RentalDesktop.Visibility = Visibility.Visible;
        }
    }
}

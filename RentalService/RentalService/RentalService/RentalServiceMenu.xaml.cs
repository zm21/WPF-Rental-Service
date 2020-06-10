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
    /// Interaction logic for RentalServiceMenu.xaml
    /// </summary>
    public partial class RentalServiceMenu : Window
    {
        public User user;
        public static string path_to_cars = "cars.xml";
        DispatcherTimer timer;
        private UserControl ActiveControl;
        public RentalServiceMenu(User user)
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
            Timer_Tick(this, EventArgs.Empty);
            HideSubMenu();
            this.user = user;
            DockPanel_UserInfo.DataContext = this.user;
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
            if (SubAccountSettings.Visibility == Visibility.Visible)
                SubAccountSettings.Visibility = Visibility.Collapsed;
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
        private void ButtonAccountSettings_Click(object sender, RoutedEventArgs e)
        {
            ShowSubMenu(SubAccountSettings);
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
        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void Btn_Home_Click(object sender, RoutedEventArgs e)
        {
            CloseActiveControl();
        }

        private void Btn_ChangeEmail_Click(object sender, RoutedEventArgs e)
        {
            OpenUserControl(new ChangeEmail(user));
        }
        private void OpenUserControl(UserControl userControl)
        {
            if (userControl is IChildWindow)
            {
                (userControl as IChildWindow).Closing += CloseActiveControl;
                (userControl as IChildWindow).OpenMsg += ShowMsg;
            }
            Desktop.Children.Clear();
            RentalDesktop.Visibility = Visibility.Hidden;
            Desktop.Children.Add(userControl);
            ActiveControl = userControl;
        }

        private void Btn_ChangePasswd_Click(object sender, RoutedEventArgs e)
        {
            OpenUserControl(new ChangePassword(user));
        }
    }
}

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

namespace RentalService
{
    /// <summary>
    /// Interaction logic for RentalServiceMenu.xaml
    /// </summary>
    public partial class RentalServiceMenu : Window
    {
        private User user;
        public static string path_to_cars = "cars.xml";
        public RentalServiceMenu(User user)
        {
            InitializeComponent();
            HideSubMenu();
            this.user = user;
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

        //private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    ButtonCloseMenu.Visibility = Visibility.Visible;
        //    ButtonOpenMenu.Visibility = Visibility.Collapsed;
        //}

        //private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    ButtonCloseMenu.Visibility = Visibility.Collapsed;
        //    ButtonOpenMenu.Visibility = Visibility.Visible;
        //}

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //UserControl usc = null;
            //GridMain.Children.Clear();

            //switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            //{
            //    case "ItemHome":
            //        usc = new UserControlHome();
            //        GridMain.Children.Add(usc);
            //        break;
            //    case "ItemCreate":
            //        usc = new UserControlCreate();
            //        GridMain.Children.Add(usc);
            //        break;
            //    default:
            //        break;
            //}
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
            if (SubRentMenu.Visibility == Visibility.Collapsed)
            {
                HideSubMenu();
                subMenu.Visibility = Visibility.Visible;
            }
            else
                SubRentMenu.Visibility = Visibility.Collapsed;
        }
        private void ButtonRent_Click(object sender, RoutedEventArgs e)
        {
            ShowSubMenu(SubRentMenu);
        }
        private void ButtonAccountSettings_Click(object sender, RoutedEventArgs e)
        {
            ShowSubMenu(SubAccountSettings);
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}

using RentalService.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace RentalService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string users_path = @"users/";
        public static string admins_path = @"admins/";
        public static string last_userId = @"users/LastUserID";
        public RegisterMViewModel registerMViewModel;
        public MainWindow()
        {
            registerMViewModel = new RegisterMViewModel();
            InitializeComponent();
            SignUP.DataContext = registerMViewModel;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void TOSignUp_Click(object sender, RoutedEventArgs e)
        {
            LOGIN.Visibility = Visibility.Hidden;
            SignUP.Visibility = Visibility.Visible;
        }

        private void TOLogin_Click(object sender, RoutedEventArgs e)
        {
            LOGIN.Visibility = Visibility.Visible;
            SignUP.Visibility = Visibility.Hidden;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            bool is_admin_try = false;
            if (chb_alogin.IsChecked==true)
            {
                is_admin_try = true;
                if (File.Exists(admins_path + logTxtBox_login.Text))
                {
                    Admin admin = new Admin();
                    admin.Deserialize(admins_path + logTxtBox_login.Text);
                    if (admin.Passwd == passwdbox.Password)
                    {
                        chb_alogin.IsChecked = false;
                        AdminMenu rentalSerivce = new AdminMenu(admin);
                        this.Hide();
                        if (rentalSerivce.ShowDialog() == true)
                            this.Show();
                        else
                            this.Close();
                    }
                    else
                    {
                        MsgBox msgBox = new MsgBox("Authorization error", "Wrong password!");
                        msgBox.Owner = this;
                        msgBox.ShowDialog();
                    }
                }
                else
                {
                    chb_alogin.IsChecked = false;
                    MsgBox msgBox = new MsgBox("Authorization error", "No user with this login was found!");
                    msgBox.Owner = this;
                    msgBox.ShowDialog();
                }
            }
            if (!is_admin_try)
                if (!File.Exists(users_path + logTxtBox_login.Text))
                {
                    MsgBox msgBox = new MsgBox("Authorization error", "No user with this login was found!");
                    msgBox.Owner = this;
                    msgBox.ShowDialog();
                }
                else
                {
                    User user = new User();
                    user.Deserialize(users_path + logTxtBox_login.Text);
                    if (user.Passwd == passwdbox.Password)
                    {
                        RentalServiceMenu rentalSerivce = new RentalServiceMenu(user);
                        this.Hide();
                        if (rentalSerivce.ShowDialog() == true)
                            this.Show();
                        else
                            this.Close();
                    }
                    else
                    {
                        MsgBox msgBox = new MsgBox("Authorization error", "Wrong password!");
                        msgBox.Owner = this;
                        msgBox.ShowDialog();
                    }
                }
        }

        private void ButtonSignUP_Click(object sender, RoutedEventArgs e)
        {
            using (var writer = new StreamWriter("emails/emails", true))
                writer.WriteLine(registerMViewModel.RegisterModel.Email);
            User user = new User(registerMViewModel.RegisterModel.Login, registerMViewModel.RegisterModel.Email, registerMViewModel.RegisterModel.ConfirmPasswd);
            user.Serialize();
            RentalServiceMenu rentalSerivce = new RentalServiceMenu(user);
            LOGIN.Visibility = Visibility.Visible;
            SignUP.Visibility = Visibility.Hidden;
            this.Hide();
            if (rentalSerivce.ShowDialog() == true)
                this.Show();
            else
                this.Close();
        }
    }
}
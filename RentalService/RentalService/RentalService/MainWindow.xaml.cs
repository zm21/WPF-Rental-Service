using RentalService.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
        PersonModel personModel = new PersonModel();
        public static string users_path = @"users/";
        public static string admins_path = @"admins/";
        public static string last_userId = @"users/LastUserID";
        public RegisterMViewModel registerMViewModel;
        public MainWindow()
        {
            registerMViewModel = new RegisterMViewModel();
            InitializeComponent();
            //this.DataContext = personModel;
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
            MsgBox msgBox = new MsgBox();
            msgBox.Owner = this;
            msgBox.ShowDialog();
        }

        private void TOLogin_Click(object sender, RoutedEventArgs e)
        {
            LOGIN.Visibility = Visibility.Visible;
            SignUP.Visibility = Visibility.Hidden;
        }
    }
    public class PersonModel : IDataErrorInfo
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "Age":
                        if ((Age < 0) || (Age > 100))
                        {
                            error = "Возраст должен быть больше 0 и меньше 100";
                        }
                        break;
                    case "Name":
                        {
                            var email_reg = new Regex(@"^[a-z,A-Z,0-9](\.?[a-z,A-Z,0-9]){5,}@[a-z]{2,}\.(com|net|ua|ru)$");
                            if (!email_reg.IsMatch(Name))
                                error = "Wrong mail";
                        }
                        break;
                    case "Position":
                        //Обработка ошибок для свойства Position
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}
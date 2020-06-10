using System;
using System.Collections.Generic;
using System.IO;
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

namespace RentalService
{
    /// <summary>
    /// Interaction logic for RemoveUser.xaml
    /// </summary>
    /// 
    public partial class RemoveUser : UserControl, IChildWindow
    {
        public Window ParentWindow { get; set; }
        
        public RemoveUser()
        {
            InitializeComponent();
        }

        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            bool valide = false;
            if (!File.Exists(MainWindow.users_path + txtbox_userLogin.Text))
            {
                ShowMsg("Deleting user error", "User not found");
            }
            else if (txtbox_userLogin.Text != "LastUserID")
                valide = true;
            if (valide)
            {
                List<string> emails = new List<string>();
                using (var reader = new StreamReader("emails/emails"))
                {
                    while (!reader.EndOfStream)
                        emails.Add(reader.ReadLine());
                }
                Users.User user_for_delete = new Users.User();
                user_for_delete.Deserialize(MainWindow.users_path + txtbox_userLogin.Text);
                emails.Remove(user_for_delete.Email);
                using (var writer = new StreamWriter("emails/emails"))
                {
                    foreach (var email in emails)
                    {
                        writer.WriteLine(email.ToString());
                    }
                }
                File.Delete(MainWindow.users_path + user_for_delete.Login);
                ShowMsg("Deleting user", "User deleted successfully");
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) => Close();

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);
    }  
}

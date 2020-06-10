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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RentalService
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : UserControl, IChildWindow
    {
        private User user;
        public ChangePassword(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);
        private void CancelButton_Click(object sender, RoutedEventArgs e) => Close();

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            bool pass_valide = false;
            bool new_pass_valide = false;
            if (oldpasswd.Password == user.Passwd)
                pass_valide = true;
            else
            {
                OpenMsg("Bad passwords", "The old password was entered incorrectly.");
            }
            if (newpasswd.Password.Length >= 5 && newpasswd.Password == confirmpasswd.Password)
                new_pass_valide = true;
            else
            {
                OpenMsg("Bad passwords", "Password must be at least 5 characters long. The passwords entered must match.");
            }
            if (new_pass_valide && pass_valide)
            {
                user.ChangePasswd(newpasswd.Password);
                user.Serialize();
                OpenMsg("Changing password", "Password changed successfully");
                Close();
            }
        }
    }
}

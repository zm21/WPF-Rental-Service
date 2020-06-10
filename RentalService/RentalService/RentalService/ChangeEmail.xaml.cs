using RentalService.Users;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ChangeEmail.xaml
    /// </summary>
    public partial class ChangeEmail : UserControl, IChildWindow
    {
        private User user;
        public ChangeEmail(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);
        private void CancelButton_Click(object sender, RoutedEventArgs e) => Close();

        private void ChangeEmail_Click(object sender, RoutedEventArgs e)
        {
            bool email_valide = false;
            if (passwdbox.Password == user.Passwd)
            {
                List<string> emails = new List<string>();
                using (var reader = new StreamReader("emails/emails"))
                {
                    while (!reader.EndOfStream)
                        emails.Add(reader.ReadLine());
                }
                var email_reg = new Regex(@"^[a-z,A-Z,0-9](\.?[a-z,A-Z,0-9]){5,}@[a-z]{2,}\.(com|net|ua|ru)$");
                if (email_reg.IsMatch(txtBox_newEmail.Text))
                    email_valide = true;
                else
                {
                    ShowMsg("Bad email", "Invalid email specified.");;
                }
                if (email_valide && emails.Contains(txtBox_newEmail.Text))
                {
                    email_valide = false;
                    ShowMsg("Bad email", "A user with this email already exists!");
                }
                if (email_valide)
                {
                    emails.Remove(user.Email);
                    user.ChangeEmail(txtBox_newEmail.Text);
                    user.Serialize();
                    emails.Add(txtBox_newEmail.Text);
                    using (var writer = new StreamWriter("emails/emails"))
                    {
                        foreach (var email in emails)
                        {
                            writer.WriteLine(email.ToString());
                        }
                    }
                    ShowMsg("Changing email", "Email changed successfully");
                    Close();
                }
            }
            else
            {
                ShowMsg("Bad passwords", "The password was entered incorrectly.");
            }
        }

    }
}

using RentalService.Users;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ReplishBalance.xaml
    /// </summary>
    public partial class ReplishBalance : UserControl, IChildWindow
    {
        private User user;
        public ReplishBalance(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);
        private void CancelButton_Click(object sender, RoutedEventArgs e) => Close();

        private void ReplishBalance_Click(object sender, RoutedEventArgs e)
        {
            bool card_num_valide = false, card_date_valid = false, cvv_cvc_valide = false;
            var card_reg = new Regex(@"(^\d{16}$)|(^\d{4} \d{4} \d{4} \d{4}$)");
            if (card_reg.IsMatch(card_num.Text))
                card_num_valide = true;
            else
            {
                ShowMsg("Payment error", "Invalid card number entered. Enter the number in the format \"1234567898765432\" or \"1234 5678 9876 5432\"");
            }

            if (card_MM.Text.Length == 2 && card_YY.Text.Length == 2)
            {
                bool date_valide = true;
                for (int i = 0; i < card_MM.Text.Length; i++)
                {
                    if (!char.IsDigit(card_MM.Text[i]))
                    {
                        date_valide = false;
                        break;
                    }
                }
                for (int i = 0; i < card_YY.Text.Length; i++)
                {
                    if (!char.IsDigit(card_YY.Text[i]))
                    {
                        date_valide = false;
                        break;
                    }
                }
                if (date_valide)
                {
                    int MM = int.Parse(card_MM.Text);
                    int YY = int.Parse(card_YY.Text);
                    if (MM > 0 && MM <= 12)
                    {
                        if (YY > 20)
                        {
                            card_date_valid = true;
                        }
                        else
                        {
                            ShowMsg("Payment error", "Invalid card expiration date. The year must be at least 21");
                        }
                    }
                    else
                    {
                        ShowMsg("Payment error", "Invalid card expiration date. Specify a month from 1 to 12. For example \"05\"");
                    }
                }
                else
                {
                    ShowMsg("Payment error", "Invalid card expiration date");
                }
            }
            else
            {
                ShowMsg("Payment error", "Invalid card expiration date");
            }

            if (card_CVV2_CVC2.Text.Length == 3)
            {
                cvv_cvc_valide = true;
                for (int i = 0; i < card_CVV2_CVC2.Text.Length; i++)
                {
                    if (!char.IsDigit(card_CVV2_CVC2.Text[i]))
                    {
                        cvv_cvc_valide = false;
                        break;
                    }
                }
            }
            if (!cvv_cvc_valide)
            {
                ShowMsg("Payment error", "Invalid card CVV2/CVC2");
            }

            if (card_num_valide && card_date_valid && cvv_cvc_valide)
            {
                user.ReplishBalance(numeric_ammount.Value);
                user.Serialize();
                ShowMsg("Replenishment of the balance", "The balance is successfully replenished");
                Close();
            }
        }   
        private void Num_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
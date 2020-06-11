using RentalService.Transport;
using RentalService.Users;
using RentCar.Transport;
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
    /// Interaction logic for RentCars.xaml
    /// </summary>
    public partial class RentCars : UserControl, IChildWindow
    {
        RentalCarViewModel rentalCarViewModel;
        User user;
        public RentCars(RentalCarViewModel rentalCarViewModel, User user)
        {
            InitializeComponent();
            this.rentalCarViewModel = rentalCarViewModel;
            this.rentalCarViewModel.UnfilteredCars();
            this.user = user;
        }

        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            rentalCarViewModel.ClearFilteredCars();
            if (isAllFiltersUnchecked())
            {
                rentalCarViewModel.UnfilteredCars();
            }
            else
            {
                foreach (var car in rentalCarViewModel.Cars)
                {
                    if (chb_available.IsChecked == true && car.Available && !rentalCarViewModel.FiltredCars.Contains(car))
                        rentalCarViewModel.AddCarToFiltred(car);

                    if (chb_sportCoupe.IsChecked == true && car.Type == chb_sportCoupe.Content.ToString() && !rentalCarViewModel.FiltredCars.Contains(car))
                        rentalCarViewModel.AddCarToFiltred(car);

                    if (chb_suv.IsChecked == true && car.Type == chb_suv.Content.ToString() && !rentalCarViewModel.FiltredCars.Contains(car))
                        rentalCarViewModel.AddCarToFiltred(car);

                    if (chb_stationWagon.IsChecked == true && car.Type == chb_stationWagon.Content.ToString() && !rentalCarViewModel.FiltredCars.Contains(car))
                        rentalCarViewModel.AddCarToFiltred(car);

                    if (chb_minivan.IsChecked == true && car.Type == chb_minivan.Content.ToString() && !rentalCarViewModel.FiltredCars.Contains(car))
                        rentalCarViewModel.AddCarToFiltred(car);

                    if (chb_electricCar.IsChecked == true && car.Type == chb_electricCar.Content.ToString() && !rentalCarViewModel.FiltredCars.Contains(car))
                        rentalCarViewModel.AddCarToFiltred(car);

                    if (chb_cabriolet.IsChecked == true && car.Type == chb_cabriolet.Content.ToString() && !rentalCarViewModel.FiltredCars.Contains(car))
                        rentalCarViewModel.AddCarToFiltred(car);

                    if (chb_sedan.IsChecked == true && car.Type == chb_sedan.Content.ToString() && !rentalCarViewModel.FiltredCars.Contains(car))
                        rentalCarViewModel.AddCarToFiltred(car);
                }
            }
        }

        private void Rent_Click(object sender, RoutedEventArgs e)
        {
            if (RentalCardGrid.SelectedItem!=null)
            {
                if (rentalCarViewModel.SelectedCar.Available)
                {
                    if (user.Balance >= numeric_numOfDays.Value * rentalCarViewModel.SelectedCar.PricePerDay)
                    {
                        rentalCarViewModel.SelectedCar.AvailableFrom = DateTime.Now;
                        rentalCarViewModel.SelectedCar.AvailableFrom = rentalCarViewModel.SelectedCar.AvailableFrom.AddDays((int)numeric_numOfDays.Value);
                        rentalCarViewModel.SelectedCar.Available = false;
                        rentalCarViewModel.SelectedCar.RentedID = user.ID;
                        user.Pay(rentalCarViewModel.SelectedCar.PricePerDay * numeric_numOfDays.Value);
                        rentalCarViewModel.SerializeCars();
                        user.Serialize();
                        Find_Click(sender, e);
                        ShowMsg("Rental success", "The car is successfully rented");
                    }
                    else
                    {
                        ShowMsg("Rental error", "There are not enough funds on your balance for this rent");
                    }
                }
                else
                {
                    ShowMsg("Rental error", "The selected car is not available");
                }
            }
            else
            {
                ShowMsg("Rental error", "You have not chosen the car you want to rent");
            }
        }

        private bool isAllFiltersUnchecked()
        {
            foreach (var item in DockFilters.Children)
            {
                if (item is CheckBox)
                {
                    if (((CheckBox)item).IsChecked==true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

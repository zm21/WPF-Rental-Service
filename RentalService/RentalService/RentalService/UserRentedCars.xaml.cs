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
    /// Interaction logic for UserRentedCars.xaml
    /// </summary>
    public partial class UserRentedCars : UserControl, IChildWindow
    {
        RentalCarViewModel rentalCarViewModel;
        User user;
        public UserRentedCars(RentalCarViewModel rentalCarViewModel, User user)
        {
            InitializeComponent();

            this.user = user;
            this.rentalCarViewModel = rentalCarViewModel;
            this.rentalCarViewModel.DeserializeCars();
            this.rentalCarViewModel.LoadUserRentedCars(this.user.ID);
            this.rentalCarViewModel.UnfilteredUserCars();
            RentalCar.UpdateCarsStatus(this.rentalCarViewModel.Cars.ToList());
        }

        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            RentalCar.UpdateCarsStatus(this.rentalCarViewModel.Cars.ToList());
            this.rentalCarViewModel.LoadUserRentedCars(this.user.ID);
            rentalCarViewModel.ClearFiltredUserCars();
            if (isAllFiltersUnchecked())
            {
                rentalCarViewModel.UnfilteredUserCars();
            }
            else
            {
                foreach (var car in rentalCarViewModel.UserRentedCars)
                {
                    if (chb_sportCoupe.IsChecked == true && car.Type == chb_sportCoupe.Content.ToString() && !rentalCarViewModel.FiltredUserCars.Contains(car))
                        rentalCarViewModel.AddUserCarToFiltred(car);

                    if (chb_suv.IsChecked == true && car.Type == chb_suv.Content.ToString() && !rentalCarViewModel.FiltredUserCars.Contains(car))
                        rentalCarViewModel.AddUserCarToFiltred(car);

                    if (chb_stationWagon.IsChecked == true && car.Type == chb_stationWagon.Content.ToString() && !rentalCarViewModel.FiltredUserCars.Contains(car))
                        rentalCarViewModel.AddUserCarToFiltred(car);

                    if (chb_minivan.IsChecked == true && car.Type == chb_minivan.Content.ToString() && !rentalCarViewModel.FiltredCars.Contains(car))
                        rentalCarViewModel.AddUserCarToFiltred(car);

                    if (chb_electricCar.IsChecked == true && car.Type == chb_electricCar.Content.ToString() && !rentalCarViewModel.FiltredUserCars.Contains(car))
                        rentalCarViewModel.AddUserCarToFiltred(car);

                    if (chb_cabriolet.IsChecked == true && car.Type == chb_cabriolet.Content.ToString() && !rentalCarViewModel.FiltredUserCars.Contains(car))
                        rentalCarViewModel.AddUserCarToFiltred(car);

                    if (chb_sedan.IsChecked == true && car.Type == chb_sedan.Content.ToString() && !rentalCarViewModel.FiltredUserCars.Contains(car))
                        rentalCarViewModel.AddUserCarToFiltred(car);
                }
            }
        }
        private bool isAllFiltersUnchecked()
        {
            foreach (var item in DockFilters.Children)
            {
                if (item is CheckBox)
                {
                    if (((CheckBox)item).IsChecked == true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

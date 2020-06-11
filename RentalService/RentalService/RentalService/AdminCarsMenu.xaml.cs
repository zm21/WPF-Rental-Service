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
    /// Interaction logic for AdminCarsMenu.xaml
    /// </summary>
    public partial class AdminCarsMenu : UserControl, IChildWindow
    {
        RentalCarViewModel rentalCarViewModel;
        public AdminCarsMenu(RentalCarViewModel rentalCarViewModel)
        {
            InitializeComponent();
            this.rentalCarViewModel = rentalCarViewModel;
            this.rentalCarViewModel.DeserializeCars();
            this.rentalCarViewModel.UnfilteredCars();
            RentalCar.UpdateCarsStatus(this.rentalCarViewModel.Cars.ToList());
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

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (RentalCardGrid.SelectedItem != null)
            {
                if (rentalCarViewModel.SelectedCar.Available)
                {
                    rentalCarViewModel.RemoveCar(rentalCarViewModel.SelectedCar);
                    rentalCarViewModel.SerializeCars();
                    Find_Click(sender, e);
                    ShowMsg("Removing car", "The car is successfully removed");
                }
                else
                {
                    ShowMsg("Removing error", "The selected car is not available");
                }
            }
            else
            {
                ShowMsg("Removing error", "You have not chosen the car you want to remove");
            }
        }
    }
}

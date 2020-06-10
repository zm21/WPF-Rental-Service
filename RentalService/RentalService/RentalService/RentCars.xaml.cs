using RentalService.Transport;
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
    public partial class RentCars : UserControl
    {
        RentalCarViewModel rentalCarViewModel;
        public RentCars(RentalCarViewModel rentalCarViewModel)
        {
            InitializeComponent();
            this.rentalCarViewModel = new RentalCarViewModel();
            this.rentalCarViewModel.UnfilteredCars();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
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

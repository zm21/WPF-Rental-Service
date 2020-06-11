using RentalService.Transport;
using RentCar.Transport;
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
    /// Interaction logic for EditCar.xaml
    /// </summary>
    public partial class AddCar : UserControl, IChildWindow
    {
        RentalCarViewModel rentalCarViewModel;
        RentalCar rentalCar;
        public AddCar(RentalCarViewModel rentalCarViewModel)
        {
            InitializeComponent();
            this.rentalCarViewModel = rentalCarViewModel;
            this.rentalCar = this.rentalCarViewModel.CarToEditOrCreate;
        }
        public event ClosingDelegate Closing;
        public event MessageDelegate OpenMsg;

        public void Close() => Closing.Invoke();

        public void ShowMsg(string title, string msg) => OpenMsg.Invoke(title, msg);

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool brand_valide = false, model_valide = false, license_plate_valide = false;

            if (txtbox_carBrand.Text.Length > 2)
            {
                brand_valide = true;
                for (int i = 0; i < txtbox_carBrand.Text.Length; i++)
                {
                    if (char.IsDigit(txtbox_carBrand.Text[i]))
                    {
                        brand_valide = false;
                        break;
                    }
                }
            }
            if (!brand_valide)
            {
                ShowMsg("Error adding car", "Entered the wrong car brand. The car brand must be longer than 2 letters and not contain other characters!");
            }

            if (txtbox_carModel.Text.Length > 2)
            {
                model_valide = true;
            }
            else
            {
                ShowMsg("Error adding car", "Entered the wrong car brand. The car brand must be longer than 2 letters and not contain other characters!");
            }

            var num_reg = new Regex(@"^[A-Z]{2}\d{4}[A-Z]{2}$");
            if (num_reg.IsMatch(txtbox_licensePlate.Text))
            {
                license_plate_valide = true;
                foreach (var car in rentalCarViewModel.Cars)
                {
                    if (car.LicensePlate == txtbox_licensePlate.Text && car.LicensePlate != rentalCar.LicensePlate)
                    {
                        license_plate_valide = false;
                        break;
                    }
                }
                if (!license_plate_valide)
                {
                    ShowMsg("Error adding car", "A car with such a license plate is already there!");
                }
            }
            else
            {
                ShowMsg("Error adding car", "The license plate of the car is incorrect");
            }
            if (brand_valide && model_valide && license_plate_valide)
            {
                rentalCar.Brand = txtbox_carBrand.Text;
                rentalCar.LicensePlate = txtbox_licensePlate.Text;
                rentalCar.Model = txtbox_carModel.Text;
                rentalCar.Type = comboBox_carType.Text;
                rentalCar.PricePerDay = numeric_pricePerDay.Value;
                rentalCar.Available = true;
                rentalCar.AvailableFrom = DateTime.Now;
                rentalCarViewModel.AddNewCar(rentalCar);
                rentalCarViewModel.SerializeCars();
                ShowMsg("Adding car", "Car added successfully");
                this.Close();
            }
        }
    }
}

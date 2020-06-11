using RentCar.Transport;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalService.Transport
{
    public class RentalCarViewModel
    {
        private ICollection<RentalCar> cars = new ObservableCollection<RentalCar>();
        public IEnumerable<RentalCar> Cars => cars;
        private ICollection<RentalCar> filtredcars = new ObservableCollection<RentalCar>();
        public IEnumerable<RentalCar> FiltredCars => filtredcars;
        public RentalCar SelectedCar { get; set; }
        public void DeserializeCars()
        {
            cars = RentalCar.DeserializeCars();
        }
        public void SerializeCars()
        {
            RentalCar.SerializeCars(cars.ToList());
        }
        public void UpdateCarsStatus()
        {
            RentalCar.UpdateCarsStatus(cars.ToList());
        }
        public void ClearFilteredCars() => filtredcars.Clear();
        public void UnfilteredCars()
        {
            ClearFilteredCars();
            foreach (var item in cars)
            {
                filtredcars.Add(item);
            }
        }
        public void AddCarToFiltred(RentalCar car)
        {
            filtredcars.Add(car);
        }
    }
}

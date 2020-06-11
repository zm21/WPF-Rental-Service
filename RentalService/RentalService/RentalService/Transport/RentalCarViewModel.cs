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

        private ICollection<RentalCar> userRentedCars = new ObservableCollection<RentalCar>();
        public IEnumerable<RentalCar> UserRentedCars => userRentedCars;

        private ICollection<RentalCar> filtredUserCars = new ObservableCollection<RentalCar>();
        public IEnumerable<RentalCar> FiltredUserCars => filtredUserCars;

        public RentalCar SelectedCar { get; set; }
        public RentalCar CarToEditOrCreate { get; set; }

        public void AddNewCar(RentalCar car) => cars.Add(car);

        public RentalCarViewModel()
        {
            CarToEditOrCreate = new RentalCar();
        }
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

        public void ClearFiltredUserCars() => filtredUserCars.Clear();

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

        public void LoadUserRentedCars(int userID)
        {
            userRentedCars.Clear();
            foreach (var item in cars)
            {
                if(item.RentedID==userID)
                    userRentedCars.Add(item);
            }
        }

        public void UnfilteredUserCars()
        {
            ClearFiltredUserCars();
            foreach (var item in userRentedCars)
            {
                filtredUserCars.Add(item);
            }
        }

        public void AddUserCarToFiltred(RentalCar car)
        {
            filtredUserCars.Add(car);
        }
        public void RemoveCar(RentalCar car)
        {
            cars.Remove(car);
        }
    }
}

using RentalService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RentCar.Transport
{
    [Serializable]
    public class RentalCar:Car
    {
        public bool Available { get; set; }
        public DateTime AvailableFrom { get; set; }
        public int RentedID { get; set; }
        public int PricePerDay { get; set; }
        public static List<RentalCar> DeserializeCars()
        {
            List<RentalCar> rentalCars = new List<RentalCar>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<RentalCar>));
            using (Stream fStream = File.OpenRead(RentalServiceMenu.path_to_cars))
            {
                rentalCars = (List<RentalCar>)xmlSerializer.Deserialize(fStream);
            }
            return rentalCars;
        }
        public static void SerializeCars(List<RentalCar> rentalCars)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<RentalCar>));
            using (Stream fStream = File.Create(RentalServiceMenu.path_to_cars))
            {
                xmlSerializer.Serialize(fStream, rentalCars);
            }
        }
        public static void UpdateCarsStatus(List<RentalCar> rentalCars)
        {
            for (int i = 0; i < rentalCars.Count; i++)
            {
                if (!rentalCars[i].Available)
                {
                    if (rentalCars[i].AvailableFrom <= DateTime.Now)
                    {
                        rentalCars[i].AvailableFrom = DateTime.Now;
                        rentalCars[i].Available = true;
                        rentalCars[i].RentedID = 0;
                    }
                }
            }
            SerializeCars(rentalCars);
        }
    }
}

using System;
using System.Threading;
namespace Opgave_1_kode_og_unit_test
{
    public class Car
    {
        private static int _nextId = 0;
        private string _model;
        private int _price;
        private string _licenseplate;
        public int Id { get; set; }
        public string Model
        {
            get => _model;
            set
            {
                if (value.Length <= 4) throw new ArgumentException("Du skal skrive mere end 3 tegn");
                //if (value.Length > 4) throw new ArgumentException("Ikke dårligt, du opfylder kravene");
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException();
                _model = value;
            }
        }
        public int Price
        {
            get => _price;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Prisen kan ikke være i minus >:(");
                _price = value;
            }
        }
        public string LicensePlate
        {
            get => _licenseplate;
            set
            {
                if (value.Length <=1 || value.Length >= 8) throw new ArgumentException("Angiv venligst en gyldig nummerplade");
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException();
                _licenseplate = value;
            }
        }

        public Car(string model, int price, string licensePlate)
        {
            Model = model;
            Price = price;
            LicensePlate = licensePlate;
            Id = Interlocked.Increment(ref _nextId);
        }

        public override string ToString()
        {
            return $"ID is: {Id}, Model is: {Model}, Price is: {Price}, License Plate is: {LicensePlate}";
        }
    }
}

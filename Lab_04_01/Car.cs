namespace Lab_04_01;

public class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, int productionYear, int maxSpeed)
    {
        Name = name;
        ProductionYear = productionYear;
        MaxSpeed = maxSpeed;
    }

    class CarComparer : IComparer<Car>
    {
        private string _sortBy;

        public CarComparer(string sortBy)
        {
            this._sortBy = sortBy;
        }

        public int Compare(Car x, Car y)
        {
            switch (_sortBy)
            {
                case "Name":
                    return x.Name.CompareTo(y.Name);
                case "ProductionYear":
                    return x.ProductionYear.CompareTo(y.ProductionYear);
                case "MaxSpeed":
                    return x.MaxSpeed.CompareTo(y.MaxSpeed);
                default:
                    throw new ArgumentException("Invalid sorting option");
            }
        }
    }

    public class CarCatalog
    {
        private Car[] _cars;
        public CarCatalog(Car[] cars)
        {
            _cars = cars;
        }
        public IEnumerable<Car> IterateForward()
        {
            for (int i = 0; i < _cars.Length; i++)
            {
                yield return _cars[i];
            }
        }
        public IEnumerable<Car> IterateBackward()
        {
            for (int i = _cars.Length - 1; i >= 0; i--)
            {
                yield return _cars[i];
            }
        }
        public IEnumerable<Car> IterateByYear(int year)
        {
            foreach (var car in _cars)
            {
                if (car.ProductionYear == year)
                {
                    yield return car;
                }
            }
        }
        public IEnumerable<Car> IterateByMaxSpeed(int maxSpeed)
        {
            foreach (var car in _cars)
            {
                if (car.MaxSpeed <= maxSpeed)
                {
                    yield return car;
                }
            }
        }



        


    }
}
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccsess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        InMemoryBrandDal memoryBrandDal = new InMemoryBrandDal();
        InMemoryColorDal memoryColorDal = new InMemoryColorDal();

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { CarId = 1, BrandId=1, ColorId =1, ModelYear=1999, DailyPrice=12000, Description="Temiz araba ama çok kullanılmış."},
                new Car { CarId = 2, BrandId=2, ColorId =1, ModelYear=2018, DailyPrice=75000, Description="Doktordan yeni hijyenik gibi araba."},
                new Car { CarId = 3, BrandId=1, ColorId =2, ModelYear=2002, DailyPrice=35000, Description="Mühendisten makine gibi araba."},
                new Car { CarId = 4, BrandId=3, ColorId =1, ModelYear=2008, DailyPrice=50000, Description="Öğretmenden öğrenci gibi araba."}
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int carId)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.CarId == carId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void GetAllByBrand(int brandId) 
        {
            var brand = memoryBrandDal.GetAll();

            var carD = from c in _cars
                       join b in brand
                       on c.BrandId equals b.BrandId
                       where b.BrandId == brandId
                       select new { CarId = c.CarId, BrandId = c.BrandId, BrandName = b.BrandName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice };

            foreach (var car in carD)
            {
                Console.WriteLine("Araba Id: {0}   Girilen marka Id:{1}  Marka: {2}   Model Yılı: {3}  Fiyatı: {4} TL"
                  , car.CarId, car.BrandId, car.BrandName, car.ModelYear, car.DailyPrice);
            }
        }

        public void GetAllByColor(int colorId)
        {
            var brand = memoryBrandDal.GetAll();
            var color = memoryColorDal.GetAll();

            var carD = from c in _cars
                       join b in brand
                       on c.BrandId equals b.BrandId
                       join cl in color
                       on c.ColorId equals cl.ColorId
                       where cl.ColorId == colorId
                       select new { CarId = c.CarId, ColorId = c.ColorId, ColorName = cl.ColorName, BrandName = b.BrandName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice };

            foreach (var car in carD)
            {
                Console.WriteLine("Araba Id: {0}  Girilen renk Id:{1}   Renk: {2}  Marka: {3}   Model Yılı: {4}  Fiyatı: {5} TL"
                  , car.CarId, car.ColorId, car.ColorName, car.BrandName, car.ModelYear, car.DailyPrice);
            }
        }

        public List<Car> GetAllById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}

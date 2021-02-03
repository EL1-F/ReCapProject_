using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _CarDal; //bir iş sınıfı başka bir sınıfı new'lemez injection yapıyoruz

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public void Add(Car car)
        {
            _CarDal.Add(car);
        }

        public void Delete(int carId)
        {
            _CarDal.Delete(carId);
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

        public void GetAllByBrand(int brandId)
        {
            _CarDal.GetAllByBrand(brandId);
        }

        public void GetAllByColor(int colorId)
        {
            _CarDal.GetAllByColor(colorId);
        }

        public List<Car> GetAllById(int carId)
        {
            return _CarDal.GetAllById(carId);
        }

        public void Update(Car car)
        {
            _CarDal.Update(car);
        }
    }
}

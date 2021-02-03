using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();

        void Add(Car car);
        void Delete(int carId);
        void Update(Car car);

        List<Car> GetAllById(int carId);
        void GetAllByBrand(int brandId);
        void GetAllByColor(int colorId);
    }
}

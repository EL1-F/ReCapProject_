using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void Delete(int brandId)
        {
            _brandDal.Delete(brandId);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public List<Brand> GetById(int brandId)
        {
            return _brandDal.GetById(brandId);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}

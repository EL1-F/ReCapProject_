using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccsess.Abstract
{
    public interface IBrandDal
    {
        List<Brand> GetAll();
        void Add(Brand brand);
        void Delete(int brandId);
        void Update(Brand brand);

        List<Brand> GetById(int brandId);
    }
}

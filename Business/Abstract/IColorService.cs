﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        void Add(Color color);
        void Delete(int colorId);
        void Update(Color color);

        List<Color> GetById(int colorId);
    }
}

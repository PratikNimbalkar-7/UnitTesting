﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IcategoryService
    {
        List<Category> GetAll();
        void Create(Category category);
        Category GetById(int? id);
    }
}

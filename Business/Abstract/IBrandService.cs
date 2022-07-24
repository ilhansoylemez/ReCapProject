﻿using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        public IResult Add(Brand brand);
        public IResult Update(Brand brand);
        public IResult Delete(Brand brand);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int id);
    }
}

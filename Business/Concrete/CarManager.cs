using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _ıCarDal;

        public CarManager(ICarDal ıCarDal)
        {
            _ıCarDal = ıCarDal;
        }
        public IResult Add(Car car)
        {
            if (car.CarName.Length >= 2 && car.DailyPrice > 0)
            {
                _ıCarDal.Add(car);
                return new SuccessResult(Messages.AddSuccesful);
            }

            else
                return new ErrorResult(Messages.AddError);
        }

        public IResult Delete(Car car)
        {
           _ıCarDal.Delete(car);
            return new SuccessResult(Messages.DeleteSuccesful);
        }

        public IDataResult<List<Car>> GetAll()
        {
         return new SuccessDataResult<List<Car>>(_ıCarDal.GetAll(),Messages.TransactionSuccesfull);
        }

        public IDataResult<List<CarDetailDto>> GetByCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_ıCarDal.GetByCarDetail(), Messages.TransactionSuccesfull);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_ıCarDal.Get(p => p.CarId == id), Messages.TransactionSuccesfull);
        }

        public IDataResult<Car> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<Car>(_ıCarDal.Get(p => p.BrandId == id), Messages.TransactionSuccesfull);
        }

        public IDataResult<Car> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<Car>(_ıCarDal.Get(p => p.ColorId == id), Messages.TransactionSuccesfull);
        }

        public IResult Update(Car car)
        {
            _ıCarDal.Update(car);
            return new SuccessResult(Messages.UpdateSuccesful);
        }
    }
}

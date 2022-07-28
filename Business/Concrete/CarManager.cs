using Business.Abstract;
using Business.CCS;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
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
        IColorService _ıColorService;


        public CarManager(ICarDal ıCarDal, IColorService ıColorService)
        {
            _ıCarDal = ıCarDal;
            _ıColorService = ıColorService;

        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run(CheckIfCarCountOfColorCorrect(car.ColorId),
                                                   CheckIfCarNameExists(car.CarName),
                                                   CheckIfColorLimitExceded());

            if (result != null)
            {
                return result;
            }
            return new SuccessResult();

        }

        public IResult Delete(Car car)
        {
            _ıCarDal.Delete(car);
            return new SuccessResult(Messages.DeleteSuccesful);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_ıCarDal.GetAll(), Messages.TransactionSuccesfull);
        }

        public IDataResult<List<CarDetailDto>> GetByCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_ıCarDal.GetByCarDetail(), Messages.TransactionSuccesfull);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_ıCarDal.Get(p => p.CarId == id), Messages.TransactionSuccesfull);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_ıCarDal.GetAll(p => p.BrandId == id), Messages.TransactionSuccesfull);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_ıCarDal.GetAll(p => p.ColorId == id), Messages.TransactionSuccesfull);
        }

        public IResult Update(Car car)
        {
            _ıCarDal.Update(car);
            return new SuccessResult(Messages.UpdateSuccesful);
        }

        private IResult CheckIfCarCountOfColorCorrect(int categoryId)
        {
            var result = _ıCarDal.GetAll(p => p.ColorId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.AddError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarNameExists(string carName)
        {
            var result = _ıCarDal.GetAll(p => p.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckIfColorLimitExceded()
        {
            var result = _ıColorService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.AddError);
            }
            return new SuccessResult();
        }
    }
}

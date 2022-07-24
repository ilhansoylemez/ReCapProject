using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _ırentaldal;
        public RentalManager(IRentalDal ırentaldal)
        {
            _ırentaldal = ırentaldal;
        }

       
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate==null)
            {
              return new  ErrorDataResult<Rental>(Messages.AddError);
            }
            else
            return new SuccessDataResult<Rental>(Messages.AddSuccesful);
            _ırentaldal.Add(rental);
        }

        public IResult Delete(Rental rental)
        {
            _ırentaldal.Delete(rental);
            return new SuccessDataResult<Rental>(Messages.DeleteSuccesful);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_ırentaldal.GetAll(), Messages.TransactionSuccesfull);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_ırentaldal.Get(p => p.RentalId == id), Messages.TransactionSuccesfull);
        }

        public IResult Update(Rental rental)
        {
            _ırentaldal.Update(rental);
            return new SuccessDataResult<Rental>(Messages.UpdateSuccesful);
        }
    }
}


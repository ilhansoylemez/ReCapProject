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
    }
}

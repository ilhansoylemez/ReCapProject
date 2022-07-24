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
    public class UserManager : IUserService
    {
        IUserDal _userdal;
        public UserManager(IUserDal userDal)
        {
           _userdal= userDal;
        }
        public IResult Add(User user)
        {
            _userdal.Add(user);
            return new SuccessResult(Messages.AddSuccesful);
        }

        public IResult Delete(User user)
        {
            _userdal.Delete(user);
            return new SuccessDataResult<User>(Messages.DeleteSuccesful);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userdal.GetAll(), Messages.TransactionSuccesfull);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userdal.Get(p => p.UserId == id), Messages.TransactionSuccesfull);
        }

        public IResult Update(User user)
        {
            _userdal.Update(user);
            return new SuccessDataResult<Rental>(Messages.UpdateSuccesful);
        }
    }
}

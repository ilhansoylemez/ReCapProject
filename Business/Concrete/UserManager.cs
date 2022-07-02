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
    }
}

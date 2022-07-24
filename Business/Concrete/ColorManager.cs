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
    public class ColorManager : IColorService
    {
        IColorDal _ıcolorDal;

        public ColorManager(IColorDal ıcolorDal)
        {
            _ıcolorDal = ıcolorDal;
        }

        public IResult Add(Color color)
        {
           _ıcolorDal.Add(color);
            return new SuccessResult(Messages.AddSuccesful);
        }

        public IResult Delete(Color color)
        {
           _ıcolorDal.Delete(color);
            return new SuccessResult(Messages.DeleteSuccesful);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_ıcolorDal.GetAll(), Messages.TransactionSuccesfull);
        }

        public IDataResult<Color> GetById(int id)
        {
           
            return new SuccessDataResult<Color>(_ıcolorDal.Get(p => p.ColorId == id), Messages.TransactionSuccesfull);
        }

        public IResult Update(Color color)
        {
            _ıcolorDal.Update(color);
            return new SuccessResult(Messages.UpdateSuccesful);
        }
    }
}

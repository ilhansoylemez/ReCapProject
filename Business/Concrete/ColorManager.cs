using Business.Abstract;
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

        public void Add(Color color)
        {
           _ıcolorDal.Add(color);
        }

        public void Delete(Color color)
        {
           _ıcolorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _ıcolorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _ıcolorDal.Get(p=> p.ColorId == id);
        }

        public void Update(Color color)
        {
            _ıcolorDal.Update(color);
        }
    }
}

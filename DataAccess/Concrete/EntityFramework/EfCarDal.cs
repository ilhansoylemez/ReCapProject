using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetByCarDetail()
        {
            using (CarContext context = new CarContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join d in context.Brands on
                             p.BrandId equals d.BrandId
                             select new CarDetailDto {CarName=p.CarName,
                                 BrandName=d.BrandName,ColorName=c.ColorName,
                                 DailyPrice = p.DailyPrice };

                return result.ToList();
            }

        }
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryProductDal()
        {
            _cars = new List<Car>()
            {
            new Car(){CarId=1,BrandId=1,ColorId=2,DailyPrice=1500,ModelYear=1995,Description="Old Car"},
            new Car(){CarId=2,BrandId=2,ColorId=3,DailyPrice=3000,ModelYear=2022,Description="New Car"},
            new Car(){CarId=3,BrandId=1,ColorId=4,DailyPrice=2500,ModelYear=2021,Description="New Car"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deleteCar = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(deleteCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetByCarDetail()
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(p => p.CarId == id);
        }

        public void Update(Car car)
        {
            Car updateCar = _cars.SingleOrDefault(p => p.CarId == car.CarId);

            updateCar.BrandId = car.BrandId;
            updateCar.ColorId = car.ColorId;
            updateCar.ModelYear = car.ModelYear;
            updateCar.DailyPrice = car.DailyPrice;
            updateCar.Description = car.Description;
        }
    }
}

using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

    CarManager carManager = new CarManager(new EfCarDal());
    var val = carManager.GetByCarDetail();
    if (val.Success==true)
    {
        foreach (var item in val.Data)
        {
            Console.WriteLine(item.CarName + " - " + item.ColorName + " - " + item.BrandName + " - " + item.DailyPrice);
        }
    }



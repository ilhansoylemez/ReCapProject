using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

User user = new User() {FirstName="Furkan",LastName="Söylemez",Email="furkan000@gmail.com",Password="321" };
UserManager userManager = new UserManager(new EfUserDal());

var a = userManager.Add(user);


Console.WriteLine("Eklendi:" + a.Message);
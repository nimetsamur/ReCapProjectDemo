using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCars();
            //DeleteCar();
            // AddRental();
            //AddUser();

        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User
            {
                FirstName = "Mustafa",
                LastName = "Samur",
                Email = "mustafasamur@gmail.com",
                Password = "12345"
            });
            Console.WriteLine(result.Message);
        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {

                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2022, 6, 8),
                ReturnDate = new DateTime()


            });
            Console.WriteLine(result.Message);
        }

        private static void DeleteCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Delete(new Car
            {
                CarId = 1007,
                CarName = "Focus",
                ColorId = 12,
                BrandId = 16,
                DailyPrice = 900,
                ModelYear = 2010

            });
            Console.WriteLine(result.Message);
        }

        private static void TestCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var c in carManager.GetProductDetails().Data)
            {
                Console.WriteLine(c.CarId + " / " + c.BrandName + " / " + c.ColorName + " / " + c.DailyPrice);

            }
        }
    }
}

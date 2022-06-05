using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var c in carManager.GetProductDetails())
            {
                Console.WriteLine(c.CarId+" / "+c.BrandName + " / " +c.ColorName + " / " +c.DailyPrice);

            }
        }
    }
}

using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length<2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else if(car.DailyPrice < 1)
            {
                return new ErrorResult(Messages.DailyPriceInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(p => p.CarId == id),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetProductDetails(), Messages.CarListed);
        }

        public IResult Updated(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}

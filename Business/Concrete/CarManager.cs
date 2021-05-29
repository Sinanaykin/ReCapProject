using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
            if (car.Description.Length < 2 )
            {
                return new ErrorResult(Messages.CarDescriptionMinTwoCharacters);
            }
            if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.DailyPriceBiggerThanZero);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            //iş kodları
            //mesela yetkisi varsa ürünleri alsın dicez.
            return new SuccessDataResult<List<Car>> (_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car> (_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.BrandId == brandId));//Car içindeki BranId eşitse bizim gönderdiğimiz brandId ye onları filtrele demek
            //ICarDal içinde tekrar bu metodtan oluturmaya gerek yok GetAll a filtre vererek yapabiliriz bunu
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.ColorId == colorId));//Car içindeki ColorId eşitse bizim gönderdiğimiz colorId ye onları filtrele demek
            //ICarDal içinde tekrar bu metodtan oluturmaya gerek yok GetAll a filtre vererek yapabiliriz bunu
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}

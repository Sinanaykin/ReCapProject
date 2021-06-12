using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidations;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
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

       // [SecuredOperation("car.add,admin")]//Ürün ekleme işlemini sadece admin yapabilir demek bu
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]//Ürün ekleyince IProductService deki  bütün Get leri siler .IProductService dedik çünkü hepsi ona bağlı.
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }


       // [SecuredOperation("car.delete")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }
        [CacheAspect]//Getaall daha önceden çağırılmışsa tekrar database den almaz veriyi cache den alır
        //[PerformanceAspect(5)]
        //[SecuredOperation("car.list")]
        
        public IDataResult<List<Car>> GetAll()
        {
            //iş kodları
            //mesela yetkisi varsa ürünleri alsın dicez.
            return new SuccessDataResult<List<Car>> (_carDal.GetAll());
        }
       
        [CacheAspect]//Getaall daha önceden çağırılmışsa tekrar database den almaz veriyi cache den alır
      //[PerformanceAspect(10)]//metodun çalışması 5 saniyeyi geçerse beni uyar dicez.Hata vermesin diye kapattık şimdilik
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car> (_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [CacheAspect(5)]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.BrandId == brandId));//Car içindeki BranId eşitse bizim gönderdiğimiz brandId ye onları filtrele demek
            //ICarDal içinde tekrar bu metodtan oluturmaya gerek yok GetAll a filtre vererek yapabiliriz bunu
        }

        [CacheAspect(5)]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.ColorId == colorId));//Car içindeki ColorId eşitse bizim gönderdiğimiz colorId ye onları filtrele demek
            //ICarDal içinde tekrar bu metodtan oluturmaya gerek yok GetAll a filtre vererek yapabiliriz bunu
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]//Ürün ekleyince IProductService deki  bütün Get leri siler .IProductService dedik çünkü hepsi ona bağlı.
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
        //[TransactionScopeAspect]//bunuda kapadık hata vermesin diye
        public IResult AddTransactionalTest(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdated); 
        }
    }
}

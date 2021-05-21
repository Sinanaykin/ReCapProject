using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            //iş kodları
            //mesela yetkisi varsa ürünleri alsın dicez.
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);//Car içindeki BranId eşitse bizim gönderdiğimiz brandId ye onları filtrele demek
            //ICarDal içinde tekrar bu metodtan oluturmaya gerek yok GetAll a filtre vererek yapabiliriz bunu
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);//Car içindeki ColorId eşitse bizim gönderdiğimiz colorId ye onları filtrele demek
            //ICarDal içinde tekrar bu metodtan oluturmaya gerek yok GetAll a filtre vererek yapabiliriz bunu
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}

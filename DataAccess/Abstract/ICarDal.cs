using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICarDal:IEntityRepository<Car> //ICarDal a  sen bir IEntityRepository sin çalışma şeklin ise Car diyoruz Yada ICarDal ı IEntityRepository den türetiyoruz T yerine Car yazıyoruz diyebiliriz.
    {
        List<CarDetailDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null);

        CarDetailDto GetCarDetails(Expression<Func<Car, bool>> filter = null);//CarDetailDto dizi olarak değilde tek dönsün diye buraya birde liste dönmeyen  CarDetailDto EKLEDİK.Getall ol çağırmak yerine  GetCarDetails çağırdık

    }
}

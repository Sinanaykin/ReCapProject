using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICarDal:IEntityRepository<Car> //ICarDal a  sen bir IEntityRepository sin çalışma şeklin ise Car diyoruz Yada ICarDal ı IEntityRepository den türetiyoruz T yerine Car yazıyoruz diyebiliriz.
    {
        List<CarDetailDto> GetCarDetails();
    }
}

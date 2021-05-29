using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);//Markaya ye göre filterereleme yapmak için bir marka id si göndermeliyiz
        IDataResult<List<Car>> GetCarsByColorId(int colorId);//Renge göre filterereleme yapmak için bir marka id si göndermeliyiz
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}


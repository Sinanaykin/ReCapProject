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
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);//Markaya ye göre filterereleme yapmak için bir marka id si göndermeliyiz
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);//Renge göre filterereleme yapmak için bir marka id si göndermeliyiz
        IDataResult<List<CarDetailDto>> GetCarsDetails();
        IDataResult<CarDetailDto> GetCarDetails(int id);
        IResult AddTransactionalTest(Car car);//uydurmaca bir metod ekledik.Transaction yönetimi :Uygulamalarda tutarlılığı korumak için yapılan bir yöntem.ben anneme para göndericem benim hesabımdan para cıktı ama anneme gitmeden sistem hata verdi durumda işlemi geri alması lazım sistemin

    }
}


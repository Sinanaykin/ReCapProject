using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public CarDetailDto GetCarDetails(Expression<Func<Car, bool>> filter )
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in  context.Cars.Where(filter) //Query expression yapısı bu ,istersen Method (Lambda expression ) ile de yapabiliriz ama Query expression daha kolay .

                             join b in context.Brands
                                    on c.BrandId equals b.BrandId
                             join co in context.Colors
                                    on c.ColorId equals co.ColorId

                             select new CarDetailDto()
                             {
                                 BrandName = b.BrandName,
                                 BrandId = b.BrandId,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 CarId = c.CarId,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description
                             };
                return result.FirstOrDefault();
            };
        }

        public List<CarDetailDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter) //Query expression yapısı bu 

                             join b in context.Brands
                                    on c.BrandId equals b.BrandId
                             join co in context.Colors
                                    on c.ColorId equals co.ColorId

                             select new CarDetailDto()
                             {
                                 BrandName = b.BrandName,
                                 BrandId = b.BrandId,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 CarId = c.CarId,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 ImagePath= context.CarImages.Where(i=>i.CarId == c.CarId).FirstOrDefault().ImagePath,//Burda mesela query expression içinde lamda expressionuda kullandık
                                 CarImages = context.CarImages.Where(i=>i.CarId == c.CarId).ToList(),

                             };
                return result.ToList();
            };
        }

    }
}

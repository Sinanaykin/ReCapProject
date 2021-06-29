using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)

                             join c in context.Cars
                             on r.CarId equals c.CarId

                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             join customer in context.Customers
                             on r.CustomerId equals customer.CustomerId

                             join color in context.Colors
                             on c.ColorId equals color.ColorId


                             join user in context.Users
                             on customer.UserId equals user.Id

                             select new RentalDetailDto()
                             {
                                 
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 BrandName = b.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnTime = r.ReturnTime,
                                 DailyPrice = c.DailyPrice
                                 //TotalPrice = Convert.ToDecimal(r.ReturnTime.Value.Day - r.RentDate.Day) * c.DailyPrice

                             };

                return result.ToList();
            };
        }

     
    }
}

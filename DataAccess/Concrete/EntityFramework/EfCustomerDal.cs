using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCustomerDal: EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (var context = new CarRentalContext())
            {

                //join customer in contex.Customers on rental.CustomerId equals customer.id
                //join user in contex.Users on customer.UserId equals user.Id
                var result = from customer in filter == null ? context.Customers : context.Customers.Where(filter)//Query expression yapısı bu 
                             join user in context.Users
                             on customer.UserId equals user.Id

                             select new CustomerDetailDto()
                             {
                                 id = customer.CustomerId,
                                 CompanyName = customer.CompanyName,
                                 CustomerName = user.FirstName + " " + user.LastName
                             };
                return result.ToList();

            };
        }

    }
}

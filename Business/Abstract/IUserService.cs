using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IResult Add(User user);//kullanıcı ekler
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<OperationClaim>> GetClaims(User user);//claimleri almak için metod
        IDataResult<User> GetByMail(string email);//maile göre kullanıcı getitir
    }
}

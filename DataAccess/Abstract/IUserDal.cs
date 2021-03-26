using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        //burada join işlemi yapacağız
        //kullanıcının veritabanından claim lerini çekmek için
        List<OperationClaim> GetClaims(User user);
    }
}

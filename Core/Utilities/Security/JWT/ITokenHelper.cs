using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //kullanıcı adı parolası girildikten sonra CreateToken çalışacak
        //veritabanına gidecek bu kullanıcıların claimlerini bulacak
        //orada jwt üretecek
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}

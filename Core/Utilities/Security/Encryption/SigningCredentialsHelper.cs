using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //kullanıcı adı, parola gibi şeyler Credentials tır.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //sen bir hashing yapacaksın anahtar olarak securityKey'i kullan, algoritma olarak ta kullanacağı algoritmayı verdik.
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}

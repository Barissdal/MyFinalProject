using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //verilen password un hashinin oluşturacak
        //kısacası bir password verilecek ve out ile dışarıya iki değişken verecek.
        //Bunlarda HMACSHA512 algoritmasıyla Salt ve Hash oluşturulmuş olacaktır.
        //Bunları AuthManager'da Login metodunda ihtiyacımız var.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                //ComputeHash metodu byte aldığı için Encoding yapıyoruz
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //kullanının passwordu nu yine aynı algoritma kullanarak hash leseydik yine aynı sonuç çıkarmıydı teyit et
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    //hesaplananla veritabanından verdiğimiz hash eşit mi?
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}

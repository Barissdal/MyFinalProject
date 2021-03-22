using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    //bunun içinde bir interface yazabiliriz ama overdesign'a doğru gidebiliriz çünkü bu bir araç
    public class BusinessRules
    {
        //Run içerisine params sayesinde istediğimz kadar IResult parametresi verebiliriz.
        //logics=iş kuralı
        public static IResult Run(params IResult[] logics)
        {
            //her bir iş kuralını gez
            foreach (var logic in logics)
            {
                //kurala uymuyorsa
                if (!logic.Success)
                {
                    //yani ErrorResult döndürecek
                    //parametre ie gönderdiğimiz iş kuralından başarısız olanı Business'a gönderiyoruz ve hatalı diyoruz.
                    return logic;
                }
            }
            return null;
        }
    }
}

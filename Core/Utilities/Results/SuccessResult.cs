using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{   
    //inheritance
    public class SuccessResult:Result
    {
        // burada base=Result demektir.
        public SuccessResult(string message):base(true,message)
        {

        }

        public SuccessResult():base(true)
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazeCredit.Models;

namespace WazeCredit.Service
{
    public class AddressValidationChecker : IValidationChecker
    {
        public string ErrorMessage => "Location validation failed";

        public bool ValidatorLogic(CreditApplication model)
        {
            if(model.PostalCode <=0 || model.PostalCode >= 99999)
            {
                return false;
            }
            return true;
        }
    }
}

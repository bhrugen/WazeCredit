using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazeCredit.Models;

namespace WazeCredit.Service
{
    public class CreditValidator : ICreditValidator
    {
        private readonly IEnumerable<IValidationChecker> _validations;
        public CreditValidator(IEnumerable<IValidationChecker> validations)
        {
            _validations = validations;
        }

        public async Task<(bool, IEnumerable<string>)> PassAllValidations(CreditApplication model)
        {
            bool validationsPassed = true;

            List<string> errorMessages = new List<string>();

            foreach(var validation in _validations)
            {
                if (!validation.ValidatorLogic(model))
                {
                    //Error
                    errorMessages.Add(validation.ErrorMessage);
                    validationsPassed = false;
                }
            }

            return (validationsPassed, errorMessages);
        }
    }
}

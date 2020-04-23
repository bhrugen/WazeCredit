using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazeCredit.Models;

namespace WazeCredit.Service
{
    public interface ICreditValidator
    {
        Task<(bool, IEnumerable<string>)> PassAllValidations(CreditApplication model);
    }
}

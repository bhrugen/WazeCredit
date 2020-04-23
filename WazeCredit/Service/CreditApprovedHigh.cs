using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazeCredit.Models;

namespace WazeCredit.Service
{
    public class CreditApprovedHigh : ICreditApproved
    {
        public double GetCreditApproved(CreditApplication creditApplication)
        {
            // have a different logic to calculate approval limit
            //we will hardcore to 30% of salary
            return creditApplication.Salary * .3;
        }
    }
}

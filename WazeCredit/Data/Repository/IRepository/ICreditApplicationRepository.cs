using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazeCredit.Models;

namespace WazeCredit.Data.Repository.IRepository
{
    public interface ICreditApplicationRepository
    {
        void Update(CreditApplication obj);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WazeCredit.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICreditApplicationRepository CreditApplication { get; }
        void Save();
    }
}

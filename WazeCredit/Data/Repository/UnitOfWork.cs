using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazeCredit.Data.Repository.IRepository;

namespace WazeCredit.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CreditApplication = new CreditApplicationRepository(_db);
        }
        public ICreditApplicationRepository CreditApplication { get; private set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

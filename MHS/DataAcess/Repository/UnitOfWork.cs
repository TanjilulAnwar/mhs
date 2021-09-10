using MHS.DataAccess.Data;
using MHS.DataAccess.Repository.IRepository;
using MHS.Models;

namespace MHS.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            IPInfo = new IPInfoRepository(_db);
        }


   

        public IIPInfoRepository IPInfo { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
             _db.SaveChanges();
        }
    }
}

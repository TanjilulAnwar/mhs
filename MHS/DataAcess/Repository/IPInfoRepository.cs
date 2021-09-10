using MHS.DataAccess.Data;
using MHS.DataAccess.Repository.IRepository;
using MHS.Models;


namespace MHS.DataAccess.Repository
{
    public class IPInfoRepository : Repository<IPInfo>, IIPInfoRepository
    {
        private readonly ApplicationDbContext _db;

        public IPInfoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(IPInfo iPInfo)
        {
            _db.ip_info.Update(iPInfo);
         
        }
    }
}

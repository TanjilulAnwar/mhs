using MHS.DataAccess.Data;
using MHS.DataAccess.Repository.IRepository;
using MHS.Models;
using System;
using System.Linq;

namespace MHS.DataAccess.Repository
{
    public class IPInfoRepository : Repository<IPInfo>, IIPInfoRepository
    {
        private readonly ApplicationDbContext _db;

        public IPInfoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public string GetIPCode()
        {
            string IPCode;
            IPInfo iPInfo = _db.ip_info.OrderByDescending(p => p.id).FirstOrDefault();
            if (iPInfo == null)
            {
                IPCode = "IP00000001";
            }
            else
            {
                string temp = iPInfo.code.Substring(2,8 );
                int code_no = Convert.ToInt32(temp);
                code_no++;
                string s = "IP"+code_no.ToString("00000000");
                IPCode =  s;
            }

            return IPCode;

        }
        public void Update(IPInfo iPInfo)
        {
            _db.ip_info.Update(iPInfo);
         
        }
    }
}

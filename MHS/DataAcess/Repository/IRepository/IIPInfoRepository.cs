using MHS.Models;


namespace MHS.DataAccess.Repository.IRepository
{
    public interface IIPInfoRepository:IRepository<IPInfo>
    {
        public void Update(IPInfo iPInfo);
    }
}

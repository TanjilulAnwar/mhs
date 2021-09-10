using System;

namespace MHS.DataAccess.Repository.IRepository
{

    public interface IUnitOfWork : IDisposable
    {
         IIPInfoRepository IPInfo { get; }
     

        void Save();
    }

}

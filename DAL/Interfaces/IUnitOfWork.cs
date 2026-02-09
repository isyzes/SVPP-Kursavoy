using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<ProviderEntity> ProviderRepository { get; }
        IRepository<ServiceEntity> ServiceRepository { get; }
        void SaveShanges();
    }
}

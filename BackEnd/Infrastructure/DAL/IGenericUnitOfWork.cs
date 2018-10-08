using Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DAL
{
    public interface IGenericUnitOfWork: IDisposable
    {
        //GenericRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
        GenericRepository<TEntity> Repository<TEntity>() where TEntity : Entity;

        Task Save();
    }
}

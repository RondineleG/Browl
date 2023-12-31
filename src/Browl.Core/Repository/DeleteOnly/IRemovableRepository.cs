﻿using System.Threading.Tasks;

namespace Browl.Core.Repository
{
    public interface IRemovableRepository<TEntity> where TEntity : class
    {
        Task Delete(TEntity entity);
    }
}

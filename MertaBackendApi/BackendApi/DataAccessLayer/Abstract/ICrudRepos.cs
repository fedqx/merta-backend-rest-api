using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.DataAccessLayer.Abstract
{
    public interface ICrudRepos<TEntity>
    {
        Task CreateAsync(TEntity Entity);
        Task DeleteAsync(short IdData);
        Task UpdateAsync(short IdData, TEntity Entity);
    }
}
